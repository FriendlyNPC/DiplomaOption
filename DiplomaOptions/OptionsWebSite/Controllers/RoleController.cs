using DiplomaDataModel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OptionsWebSite.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        new RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        
        // GET: Role
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }

        // GET: Role/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var userList = new List<String>();
            
            foreach(var user in role.Users)
            {
                   userList.Add(UserManager.FindById(user.UserId).UserName);
            }

            ViewBag.Users = userList;

            return View(role);
        }

        // GET: Role/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Add(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var userList = new List<String>();
            
            foreach (var user in role.Users)
            {
                userList.Add(UserManager.FindById(user.UserId).UserName);
            }

            ViewBag.Users = userList;

            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var userList = new List<SelectListItem>();
            /*
            foreach (var user in role.Users)
            {
                new SelectListItem {

                    //Text: userList.Add(UserManager.FindById(user.UserId).UserName)
                }
            }
            */
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Role/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            var userList = new List<String>();

            foreach (var user in role.Users)
            {
                userList.Add(UserManager.FindById(user.UserId).UserName);
            }

            ViewBag.Users = userList;

            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
