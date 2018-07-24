using Roomy.Areas.BackOffice.Models;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;
using Roomy.Filters;

namespace Roomy.Areas.BackOffice.Controllers
{
    public class AuthenticationController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: BackOffice/Authentification/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: BackOffice/Authentification/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModels model)
        {
            if (ModelState.IsValid)
                {
                var passwordHash = model.Password.HashMD5();

                var user = db.Users.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (user == null)
                {
                    //1
                    //ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");

                    //2
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect";

                    return View(model);
                    //return RedirectToAction("Login");
                }
                else
                {
                    Session.Add("USER_BO", user);
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" });
                }
            }
            return View(model);
        }

        // GET: BackOffice/Authentification/LogOut
        [AuthenticationFilter]
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
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