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

namespace StripMall.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private IHostingEnvironment hostingEnvironment;
        private readonly AppDbContext context;

        //private SignInManager<ApplicationUser> signInManager;

        public AdministrationController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           IHostingEnvironment hostingEnvironment,
           AppDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
            //this.signInManager = signInManager;
            //    this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ApplicationUser> sellers = await userManager.GetUsersInRoleAsync("Seller");
            return View(sellers);
        }

        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
            
                };

                var result = await userManager.CreateAsync(user, model.Password);

                var Roles = await userManager.AddToRoleAsync(user, "Admin");
                if (result.Succeeded)
                {
                    TempData["msg"] = "New admin added with id" + model.Email;
                    ModelState.Clear();
                    return View();
                }
            }
            return View(model);
        }
        

        [HttpGet]
        public IActionResult ShowFeedBacks()
        {
            IEnumerable<Feedback> FBs = context.Feedbacks.OrderByDescending(x=>x.Date).ToList(); 
            return View(FBs);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.categories = context.Categories.ToList();//, "CategoryId", "CategoryName");
            return View();
        }

        public async Task<RedirectToActionResult> delCategory(int Id)
        {
            try
            {
                Category category = await context.Categories.FindAsync(Id);
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                TempData["DelSuccess"] = "Category Deleted!";
                return RedirectToAction("AddCategory");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("ReferentialIntegrity", "Error");
            }
        }

       [HttpPost]
        public async Task<IActionResult> AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                await context.Categories.AddAsync(new Category
                {
                    CategoryName = model.CategoryName
                });
                await context.SaveChangesAsync();
                TempData["Success"] = "Category Added!";
                ModelState.Clear();
            }
            ViewBag.categories = context.Categories.ToList();   
            return View();
        }

        

        [HttpGet]
        public IActionResult AddSeller()
        {
            ViewBag.locations = new SelectList(context.Locations, "LocationId", "LocationName");
            ViewBag.shopTypes = new SelectList(context.shopTypes, "Id", "Type");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller(AddSellerViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if(model.ShopPhoto !=null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images\\shop");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ShopPhoto.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ShopPhoto.CopyTo(fileStream);
                    }
                }
                Location location = await context.Locations.FindAsync(model.location);
                ShopType type = await context.shopTypes.FindAsync(model.shopType);
                ApplicationUser seller = new ApplicationUser
                {
                    ShopName = model.ShopName,
                    UserName = model.Email,
                    UserLocation = location,
                    LocName = location.LocationName,
                    shopType = type,
                    TypeName = type.Type,
                    Email = model.Email,
                    AddrLine1 = model.AddressLine1,
                    AddrLine2 = model.AddressLine2,
                    PinCode = model.PinCode,
                    PhoneNumber = model.PhoneNumber,
                    PhotoPath = uniqueFilename,
                    IsShopOpen = false
                };

                var result = await userManager.CreateAsync(seller, model.Password);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(seller, "Seller");
                    ModelState.Clear();
                    TempData["Success"] = "Shop Added!";
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }

        public async Task<RedirectToActionResult> delRole(string Id)
        {
            try
            {
                TempData["DelSuccess"] = "Role Deleted!";
                IdentityRole role = await context.Roles.FindAsync(Id);
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
                return RedirectToAction("CreateRole");
            }
            catch(DbUpdateException)
            {
                return RedirectToAction("ReferentialIntegrity", "Error");
            }            
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("CreateRole");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddLocation()
        {
            ViewBag.LocNames = context.Locations.ToList();
            return View();
        }

        public async Task<RedirectToActionResult> delLocation(Guid Id)
        {
            try
            {
                Location location = await context.Locations.FindAsync(Id);
                context.Locations.Remove(location);
                await context.SaveChangesAsync();
                TempData["DelSuccess"] = "Location Deleted!";
                return RedirectToAction("AddLocation");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("ReferentialIntegrity", "Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddLocationAsync(Location model)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location
                {
                    LocationName = model.LocationName,
                    TLChatId = model.TLChatId,
                    TLToken = model.TLToken
                };
                await context.Locations.AddAsync(location);
                await context.SaveChangesAsync();
                ModelState.Clear();
                TempData["Success"] = "Location added!";
            }
            return View();
        }



        [HttpGet]
        public IActionResult AddShopType()
        {
            ViewBag.shopTypes = context.shopTypes.ToList();
            return View();
        }

        public async Task<RedirectToActionResult> delShopType(int type)
        {
            try
            {
                ShopType shopType = await context.shopTypes.FindAsync(type);
                context.shopTypes.Remove(shopType);
                await context.SaveChangesAsync();
                TempData["DelSuccess"] = "Shop Type Deleted!";
                return RedirectToAction("AddShopType");
            }
            catch(DbUpdateException)
            {
                return RedirectToAction("ReferentialIntegrity", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddShopType(ShopType model)
        {
            if (ModelState.IsValid)
            {
                ShopType type = new ShopType
                {
                    Type = model.Type
                };
                await context.shopTypes.AddAsync(type);
                await context.SaveChangesAsync();
                TempData["Success"] = "Shop Type Added!";
                ModelState.Clear();
            }
            ViewBag.shopTypes = context.shopTypes.ToList();
            return View();
        }
    }
}
