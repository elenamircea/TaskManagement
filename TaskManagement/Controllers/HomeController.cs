using DomainClasses;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TaskManagement.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Home/Details/5
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = AppUserManager.Create(null, HttpContext.GetOwinContext());
                var authManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.Email, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(Url.Action("Index", "Task"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        // GET: /Home/Register
        public ActionResult Register()
        {
            return View();
        }

        // Post: /Home/Register
        [HttpPost]
        public async Task<ActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = AppUserManager.Create(null, HttpContext.GetOwinContext());

                var user = new AppUser() { UserName = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Task");
                }
                else
                {
                    //AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);

        }

        // GET: /Home/Logout
        public ActionResult LogOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Home");
        }

        private async System.Threading.Tasks.Task SignInAsync(AppUser user, bool isPersistent)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userManager = AppUserManager.Create(null, HttpContext.GetOwinContext());

            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

    }
}
