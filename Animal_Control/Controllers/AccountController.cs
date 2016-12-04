using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Controllers;
using Animal_Control.Models;
using System.Web.Security;

namespace Animal_Control.Controllers
{
    public class AccountController : Controller
    {

        private AnimalControl db = new AnimalControl();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AC_Usuario u)
        {
          
                if (IsValid(u.Correo, u.Contraseña))
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == u.Correo);
                    if (userLog == null) return View(u);
                    FormsAuthentication.SetAuthCookie(u.Correo, false);

                    return RedirectToAction("Index", "Animal");
                }
                else
                {
                    ModelState.AddModelError("", "");
                }

            return View(u);
        }

        private static bool IsValid(string email, string password)
        {
            var isValid = false;

            using (var db = new AnimalControl())
            {
                var user = db.AC_Usuario.FirstOrDefault(u => u.Correo == email);
                if (user == null) return isValid;
                if (user.Contraseña == password)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}