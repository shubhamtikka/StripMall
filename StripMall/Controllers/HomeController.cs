using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StripMall.Models;
using StripMall.ViewModels;

namespace StripMall.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private IItemsRepository itemsRepository;
        private readonly AppDbContext context;
        private UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        IEnumerable<ApplicationUser> Sellers;
        IEnumerable<Items> itemsList;

        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IItemsRepository itemsRepository,
            AppDbContext context)
        {
            this.itemsRepository = itemsRepository;
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> AboutUs(Feedback fb)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
                Feedback feedback = new Feedback
                {
                    FeedBackText = fb.FeedBackText,
                    CustomerId = user.Email,
                    Date = DateTime.Now
                };
                await context.Feedbacks.AddAsync(feedback);
                await context.SaveChangesAsync();
                ModelState.Clear();
                
            }
            return View(fb);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.Locations = new SelectList(context.Locations.ToList(), "LocationId", "LocationName");
            Sellers = await userManager.GetUsersInRoleAsync("Seller");
            ViewBag.shopTypes = new SelectList(context.shopTypes.ToList(), "Id", "Type");
            return View(Sellers);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PropChanged(Guid? Location, int? type)
        {
            ViewBag.Locations = new SelectList(context.Locations.ToList(), "LocationId", "LocationName");
            ViewBag.shopTypes = new SelectList(context.shopTypes.ToList(), "Id", "Type");
            Location location = await context.Locations.FindAsync(Location);
            ShopType SType = await context.shopTypes.FindAsync(type);

            Sellers = await userManager.GetUsersInRoleAsync("Seller");
            List<ApplicationUser> u = new List<ApplicationUser>();
            if((location == null) && (SType == null))
            {
                return View("Index", Sellers);
            }
            else if((location == null) || (SType == null))
            {
                if(location != null)
                {
                    foreach (ApplicationUser user in Sellers)
                    {
                        if (location.LocationName == user.LocName)
                        {
                            u.Add(user);
                        }
                    }
                    return View("Index", u);
                }
                else
                {
                    foreach (ApplicationUser user in Sellers)
                    {
                        if (SType.Type == user.TypeName)
                        {
                            u.Add(user);
                        }
                    }
                    return View("Index", u);
                }
            }
            else
            {
                foreach (ApplicationUser user in Sellers)
                {
                    if ((location.LocationName == user.LocName) && (SType.Type == user.TypeName))
                    {
                        u.Add(user);
                    }
                }
                return View("Index", u);
            }

        }

        [AllowAnonymous][HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }


        [AllowAnonymous]
        public ViewResult SeeItems(string id, int? category)
        {
            ViewBag.shopName = context.Users.Find(id).ShopName;
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "CategoryName");
                itemsList = itemsRepository.GetAllItems(id, category);
                return View(itemsList);           
        }


        

        //Implementation of SearchItem
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SearchItem()
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "CategoryName");
            ViewBag.IsPost = false;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SearchItem(string searchTerm)
        {
            //ViewBag.NumList = new SelectList(Enumerable.Range(1, 10), 1);
            ViewBag.IsPost = true;
            itemsList = null;
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(itemsList);
            }
            else
            {
                itemsList = context.S_items.Include(u => u.Seller).
                    Where(x => x.ItemName.StartsWith(searchTerm, true, null)); 
                return View(itemsList); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageAddress()
        {
            List<Location> locations = context.Locations.ToList();
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            if (user.LocName != null)
            {
                var selected = context.Locations.Where(a => a.LocationName == user.LocName).Select(x => x.LocationId).FirstOrDefault();
                ViewBag.locations = new SelectList(context.Locations, "LocationId", "LocationName", selected);
                AddressViewModel model = new AddressViewModel
                {
                    AddressLine1 = user.AddrLine1,
                    AddressLine2 = user.AddrLine2,
                    PhoneNumber = user.PhoneNumber,
                    PinCode = user.PinCode
                };
                return View(model);
            }
            else
            {
                ViewBag.locations = new SelectList(context.Locations, "LocationId", "LocationName");
                return View();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ManageAddress(AddressViewModel model)
        {
            List<Location> locations = context.Locations.ToList();
            ViewBag.locations = new SelectList(context.Locations, "LocationId", "LocationName");
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            Location location = await context.Locations.FindAsync(model.location);
            if (ModelState.IsValid)
            {
                user.UserLocation = location;
                user.LocName = location.LocationName;
                user.AddrLine1 = model.AddressLine1;
                user.AddrLine2 = model.AddressLine2;
                user.PinCode = model.PinCode;
                user.PhoneNumber = model.PhoneNumber;
            }
            TempData["msg"] = "Add your address to place order.";
            await context.SaveChangesAsync();
            return View();
        }

        [Produces("application/json")]
        [HttpGet("JQGetItems")]
        [AllowAnonymous]
        public IActionResult JQGetItems()
        {
            string term = HttpContext.Request.Query["term"].ToString();

            List<string> items = context.S_items.Include(u => u.Seller).
                Where(x => x.ItemName.StartsWith(term, true, null)).Select(i => i.ItemName).ToList();
            return Ok(items);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
