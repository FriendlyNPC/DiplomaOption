using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Student") && !User.IsInRole("Admin")) {
                    return RedirectToAction("Create", "Choice");
                }
                else if(User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Choice");
                } 
            } else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}