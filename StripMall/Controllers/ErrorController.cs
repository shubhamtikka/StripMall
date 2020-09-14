using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StripMall.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch(statusCode)
            {
                case 404 :
                    ViewBag.msg = "Sorry, The requested page could not be found.";
                    break;
            }
            return View();
        }

        public IActionResult ReferentialIntegrity()
        {
            ViewBag.ErrorMessage = "The Entity you are trying to delete is used by other entites, " +
                                    "Make sure it is not in use then try again.";
            return View();
        }
    }
}