using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LoginAuth.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using LoginAuth.DAL;
using System.IO;
using System.Net;



namespace LoginAuth.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        ApplicationDbContext db = new ApplicationDbContext();
        private AttendanceDB ucok2 = new AttendanceDB();

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult Index()
        {

            var jhon = (from k in db.Users select k).ToList();
            ViewBag.loop = jhon;
            
            ViewBag.how = "";
            ViewBag.see = "";
            ViewBag.yui = TempData["delete"];
            var userId = User.Identity.GetUserId();
            var UserName = User.Identity.GetUserName();
            var Uwak = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var s = Uwak.GetRoles(userId);
            if (s[0].ToString() == "Admin")
            {
                ViewBag.show = true;
            }
            else
            {
                ViewBag.show = false;
            }
            var validasiUp = (from j in ucok2.FileUploads where j.UserId == userId select j).ToList();
            if (validasiUp.Any())
            {
                ViewBag.don = "ada";
            }
            else
            {
                ViewBag.don = "kosong";
            }

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();

        }

        public ActionResult Edit(string id)
        {
            var cari = (from pencarian in db.Users where pencarian.Id == id select pencarian).ToList();
            return View(cari);
        }
        public ActionResult Delete(string id)
        {
            ViewBag.how = "";
            ViewBag.see = "";
            var cari = (from pencarian in db.Users where pencarian.Id == id select pencarian).ToList();
            ViewBag.del = cari;
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var hilangkan = db.Users.Find(id);
            db.Users.Remove(hilangkan);
            db.SaveChanges();
            TempData["delete"] = "Data Has Been Delete";
            return RedirectToAction("Index");
        }
        public ActionResult Status(string id)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userId = UserManager.FindById(id).Id;
            if (UserManager.GetLockoutEnabled(userId) == true)
            {
                UserManager.SetLockoutEnabled(userId, false);
            }
            else
            {
                UserManager.SetLockoutEnabled(userId, true);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}