using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StripMall.Models;
using StripMall.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace StripMall.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppDbContext context;

        //private readonly RoleManager<ApplicationUser> roleManager;

        ApplicationUser user;

        public IEmailSender emailSender { get; }

        //private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IEmailSender emailSender,
            AppDbContext context)
            //RoleManager<ApplicationUser> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.context = context;
            
            //this.roleManager = roleManager;
            //this.logger = logger;
        }

        public RedirectToActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.EmailId);
                if (user != null && !user.EmailConfirmed &&
                    (await userManager.CheckPasswordAsync(user,model.Password)))
                    {
                        ModelState.AddModelError(string.Empty,"Email not confirmed yet.");
                        return View(model);
                    }
                var result = await signInManager.PasswordSignInAsync(model.EmailId, 
                    model.Password,model.RememberMe,
                    false);

                user = await userManager.FindByEmailAsync(model.EmailId);

                if (result.Succeeded)
                {
                    if (await userManager.IsInRoleAsync(user, "Customer"))
                    {
                        return RedirectToAction("index", "Home");
                    }
                    else if (await userManager.IsInRoleAsync(user, "Seller"))
                    {
                        return RedirectToAction("Index", "Sell");
                    }
                    else
                    {
                        return RedirectToAction("index", "Administration");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login attempt!");
            }
            return View(model);
        }
              

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = code },
                        Request.Scheme);

                    await userManager.AddToRoleAsync(user, "Customer");

                    await emailSender.SendEmailAsync(user.Email, $"Email confirmation","click on this link to confirm email"+
                       $"-> {callbackUrl}  Contact us if not requested!");

                    
                    TempData["msg"] = "Your account has been created. Kindly confirm email before sign in";
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.msg = "User not found!";
            var user = await userManager.FindByIdAsync(userId);

            if(user == null)
            {
                ViewBag.msg = "User not found!";
                return View();
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                ViewBag.msg = "Email confirmed!";
                return View();
            }

            return View();
        }
    }
}