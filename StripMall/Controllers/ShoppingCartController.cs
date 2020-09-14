using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StripMall.Models;

namespace StripMall.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IItemsRepository itemsRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly UserManager<ApplicationUser> userManager;

        public ShoppingCartController(IItemsRepository itemsRepository,
            IShoppingCart shoppingCart, UserManager<ApplicationUser> userManager)
        {
            this.itemsRepository = itemsRepository;
            this.shoppingCart = shoppingCart;
            this.userManager = userManager;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        public async Task<RedirectToActionResult> AddToCart(int amt, Guid id)
        {
            Items selectedItem = itemsRepository.GetItem(id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            //string userId =  user.Id.ToString();
            if (selectedItem != null)
            {
                await shoppingCart.AddToCartAsync(selectedItem, amt, user);
            }
            TempData["added"] = "Item has been added to cart.";
            return RedirectToAction("SeeItems","Home",new { id = selectedItem.Id });
        }

        [HttpGet]
        public async Task<IActionResult> ViewCartAsync()
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            var sitems = shoppingCart.GetCart(user.Id);
            return View(sitems);
        }

        public async Task<RedirectToActionResult> InCountAsync(string Uid, string Iid)
        {
            await shoppingCart.InCount(Uid, Iid);
            return RedirectToAction("ViewCartAsync");
        }
        public async Task<RedirectToActionResult> DecCountAsync(string Uid, string Iid)
        {
            await shoppingCart.DecCount(Uid,Iid);
            return RedirectToAction("ViewCartAsync");
        }
        public async Task<RedirectToActionResult> DelFromCartAsync(string Uid, string Iid)
        {
            await shoppingCart.DelFromCart(Uid, Iid);
            return RedirectToAction("ViewCartAsync");
        }

    }
}