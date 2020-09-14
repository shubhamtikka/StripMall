using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StripMall.Models;
using StripMall.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StripMall.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellController : Controller
    {
        private IItemsRepository itemsRepository;
        private UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly AppDbContext context;

        ApplicationUser Shop;

        public SellController(IItemsRepository itemsRepository, 
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment,
            AppDbContext context)
        {
            this.itemsRepository = itemsRepository;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Shop = await userManager.GetUserAsync(HttpContext.User);
            IEnumerable<Orders> NewOrders = context.OrderDetails.Include(o => o.Order).
                                    Where(s => (s.SellerId == Shop.Id)).
                                    Where(o => o.Order.OrderDate.Date == DateTime.Now.Date).
                                    Select(o => o.Order).Distinct();
            return View(NewOrders.OrderByDescending(x => x.OrderDate));
        }

        // GET: /<controller>/
        public async Task<IActionResult> ViewAllOrders()
        {
            Shop = await userManager.GetUserAsync(HttpContext.User);
            TempData["shoBtn"] = false;
            IEnumerable<Orders> orders = context.OrderDetails.Include(o => o.Order).
                                   Where(s => (s.SellerId == Shop.Id)).
                                   Select(o => o.Order).Distinct();
            return View("Index",orders.OrderByDescending(x => x.OrderDate));
        }
        

        [HttpGet]
        public async Task<IActionResult> ShowItemsNew(int? category)
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "CategoryName");
            Shop = await userManager.GetUserAsync(HttpContext.User);
            var users = itemsRepository.GetAllItems(Shop.Id,category);   
            return View(users);
        }

        [HttpGet]
        public IActionResult EditItems(Guid id)
        {
            Items item = itemsRepository.GetItem(id);
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(item);
        }

        [HttpPost]
        public IActionResult EditItems(Items itemsChanges)
        {
            Items item = itemsRepository.GetItem(itemsChanges.ItemsId);
            item = itemsRepository.UpdateItem(item, itemsChanges);
            return View("ItemDetails", item);
        }


        [HttpGet]
        public IActionResult AddItems()
        {
            ViewBag.Categories = new SelectList(context.Categories , "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItems(AddItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (model.ItemPhoto != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images\\item");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ItemPhoto.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ItemPhoto.CopyTo(fileStream);
                    }
                }

                Shop = await userManager.GetUserAsync(HttpContext.User);
                await itemsRepository.AddItem(new Items
                {
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice,
                    ItemDesc = model.ItemDesc,
                    ItemWeight = model.ItemWeight,
                    Seller = Shop,
                    category = await context.Categories.FindAsync(model.Category),
                    Id = Shop.Id,
                    IsInStock = true,
                    PhotoPath = uniqueFilename
                });

                ModelState.Clear();
                return View();  
            }

            return View(model);
        }

        public async Task<RedirectToActionResult> DeleteItem(Guid id)
        {
            await itemsRepository.DeleteItem(id);
            return RedirectToAction("ShowItemsNew");
        }

        [HttpGet][AllowAnonymous]
        public IActionResult ItemDetails(Guid id)
        {
            Items item = itemsRepository.GetItem(id);
            return View(item);
        }

        public async Task<RedirectToActionResult> ChangeStatusAsync(Guid id)
        {
            await itemsRepository.ChangeStatus(id);
            return RedirectToAction("ShowItemsNew");
        }

        public async Task<RedirectToActionResult> ManageShop()
        {
            Shop = await userManager.GetUserAsync(HttpContext.User);
            Shop.IsShopOpen = Shop.IsShopOpen ? false : true;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrderAsync(string id)
        {
            IEnumerable<OrderDetails> orderD = context.OrderDetails.Where(x => x.OrderId == id);
            Orders order = await context.Orders.FindAsync(id);
            ViewBag.OrderId = id;
            ViewBag.UserId = order.AppUserId;
            return View(orderD);
        }
    }
}
