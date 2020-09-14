using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripMall.Models;
using Telegram.Bot;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace StripMall.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IShoppingCart shoppingCart;
        private readonly IEmailSender emailsender;
        ApplicationUser user;
        public OrderController(AppDbContext context, UserManager<ApplicationUser> userManager
            , IShoppingCart shoppingCart,
            IEmailSender emailsender)
        {
            this.context = context;
            this.userManager = userManager;
            this.shoppingCart = shoppingCart;
            this.emailsender = emailsender;
            this.userManager = userManager;
        }
        private TelegramBotClient bot;

        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> ViewOrders()
        {
            user = await userManager.GetUserAsync(HttpContext.User);
            List<Orders> orders = context.Orders.Where(x => x.AppUserId == user.Email).ToList();
            return View(orders);
        }

        public IActionResult ViewOrder(string id)
        {
            List<OrderDetails> orderDetails = context.OrderDetails.Where(x => x.OrderId == id).ToList();
            return View(orderDetails);
        }

        public async Task<IActionResult> PlaceOrderAsync()
        {
            user = await userManager.GetUserAsync(HttpContext.User);

            if (user.LocName == "" || user.LocName == null)
            {
                TempData["msg"] = "Add your address to place order.";
                return RedirectToAction("ManageAddress", "Home");
            }
            else
            {

                var sitems = shoppingCart.GetCart(user.Id).OrderBy(x=>x.SellerId);

                if (sitems.Count() != 0)
                {
                    var OrderId = user.Id.ToString().Substring(0, 2)
                        + Orders.GenerateOrderId().ToString();

                    Orders order = new Orders
                    {
                        OrderId = OrderId,
                        AppUserId = user.Email,
                        OrderTotal = sitems.Sum(x => x.ItemTotal),
                        OrderDate = DateTime.Now
                    };
                    await context.Orders.AddAsync(order);
                    foreach (ShoppingCartItem item in sitems)
                    {
                        OrderDetails orderdetail = new OrderDetails
                        {
                            Order = order,
                            OrderId = order.OrderId,
                            SellerId = item.SellerId,
                            ShopName = item.ShopName,
                            ItemName = item.ItemName,
                            ItemPrice = item.ItemPrice,
                            ItemCount = item.ItemCount,
                            ItemTotal = item.ItemTotal
                        };
                        await context.OrderDetails.AddAsync(orderdetail);
                    }
                    await context.SaveChangesAsync();

                    string CustomerInfo = "****Customer Info**** \n";

                    CustomerInfo += "Name: " + user.FirstName + " " + user.LastName;
                    CustomerInfo += "Address: " + user.AddrLine1 + ", " + user.AddrLine2 + "," + user.PinCode;
                    CustomerInfo += "Contact:" + user.PhoneNumber + "\n";

                    var Itemshop = context.Users.Include(u => u.UserLocation).
                        Where(x => x.Id == (sitems.First().SellerId)).First();

                    
                    string shopInfo = "****Shop Info**** : " + "\n";

                    List<string> shops = sitems.Select(x => x.SellerId).Distinct().ToList();
                    ApplicationUser shop;
                    string callBackUrl = this.Url.Action("Index", "Sell", null, this.Request.Scheme);//,, Request.Scheme);
                    foreach (string id in shops)
                    {
                        shop = await context.Users.FindAsync(id);
                        shopInfo += "  ShopName: " + shop.ShopName + "\n";
                        shopInfo += "ShopAddress: " + shop.AddrLine1 + ", " + shop.AddrLine2 + "," + shop.PinCode + "\n";
                        shopInfo += "ShopContact:" + shop.PhoneNumber + "\n";
                        shopInfo += "ShopContact:" + shop.PhoneNumber + "\n";

                        await emailsender.SendEmailAsync(shop.Email, $"New Order from {user.Email}", $"View order : {callBackUrl}");

                    }

                    string Data = shopInfo + CustomerInfo;

                    SendMsgAsync(Itemshop.UserLocation, Data);
                    shoppingCart.ClearCart(user.Id);

                    return View();

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public async void SendMsgAsync(Location l, string Data)
        {
            bot = new TelegramBotClient(l.TLToken);
            await bot.SendTextMessageAsync(l.TLChatId, Data);
            
        }
    }
}