using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LBCFUBL.Models;
using LBCFUBL.Services;

namespace LBCFUBL.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                LBCFUBL_WCF.DBO.User user = Helper.GetUserClient().GetUserFromLogin(model.Username);

                if (user != null)
                {
                    if (user.password == LBCFUBL_WCF.DataAccess.User.CalculateMD5Hash(model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                        LBCFUBL_WCF.DBO.User u = Helper.GetUserClient().GetUserFromLogin(model.Username);
                        model.role = LBCFUBL_WCF.DataAccess.User.RoleFromInt(u.role).ToString();
                        FormsAuthentication.RedirectFromLoginPage(model.Username, model.RememberMe);
                    }
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login", null);
        }
    }
}