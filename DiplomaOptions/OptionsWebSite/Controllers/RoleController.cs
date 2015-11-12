using DiplomaDataModel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            ViewBag.Error = "";
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Name")] IdentityRole identityRole)
        {
            string name = identityRole.Name;

            //validate name
            if (name == null || name.Equals("") )
            {
                ViewBag.Error = "Role name is required";
                ViewBag.name = "";
                return View();
            }

            ViewBag.name = name;

            if (name.Length > 40)
            {
                ViewBag.Error = "Role name cannot be longer than 40 characters";
                return View(identityRole);
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_-]{1,40}$"))
            {
                ViewBag.Error = "Invalid Role name";
                return View(identityRole);
            }
            

            if (roleManager.RoleExists(name))
            {
                ViewBag.Error = "A role by that name already exists.";
                return View(identityRole);
            }

            roleManager.Create(new IdentityRole(name));
            return RedirectToAction("Index");    
            
        }

        // GET: Role/Add
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

            var usersNotInRole = db.Users.Where(m => m.Roles.All(r => r.RoleId != role.Id)).ToList();

            var userList = new SelectList(usersNotInRole, "id", "UserName");


            ViewBag.UserList = userList;
            ViewBag.RoleName = role.Name;

            return View(role);
        }

        // POST: Role/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(string id, FormCollection collection)
        {
            var userId = collection.GetValue("UserId").AttemptedValue;
            var role = roleManager.FindById(id);

            var user = db.Users.Find(userId);

            if(user == null)
            {
                ViewBag.Error = "User does not exist";
                var usersNotInRole = db.Users.Where(m => m.Roles.All(r => r.RoleId != role.Id)).ToList();
                var userList = new SelectList(usersNotInRole, "id", "UserName");
                ViewBag.UserList = userList;
                ViewBag.RoleName = role.Name;

                return View();
            }

            var inRole = role.Users.Where(i => i.UserId == user.Id).Count();

            if (inRole > 0)
            {
                ViewBag.Error = "User is already in role";
                var usersNotInRole = db.Users.Where(m => m.Roles.All(r => r.RoleId != role.Id)).ToList();
                var userList = new SelectList(usersNotInRole, "Id", "UserName");
                ViewBag.UserList = userList;
                ViewBag.RoleName = role.Name;

                return View();
            }

            UserManager.AddToRole(user.Id, role.Name);
            

            return RedirectToAction("Index");
        }

        // GET: Role/Remove/5
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

            ViewBag.Error = "";
            ViewBag.RoleName = role.Name;
            
            var usersInRole = db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();
            var userList = new SelectList(usersInRole, "Id", "UserName");
            ViewBag.UserList = userList;

            return View(role);
        }

        // POST: Role/Remove/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Remove(string id, FormCollection collection)
        {

            var userId = collection.GetValue("UserId").AttemptedValue;
            var role = roleManager.FindById(id);

            var user = db.Users.Find(userId);

            if (userId == null)
            {
                return RedirectToAction("Index");
            }

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            UserManager.RemoveFromRole(userId, role.Name);
            
            return RedirectToAction("Index");
            
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
        public ActionResult DeleteConfirmed(string id)
        {

            var role = roleManager.FindById(id);

            var userList = role.Users;

            foreach (var user in userList)
            {
                UserManager.RemoveFromRole(user.UserId, role.Id);
            }

            roleManager.Delete(role);

            return RedirectToAction("Index");
        }
    }
}
