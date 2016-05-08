using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DomainClasses;
using DataLayer;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/
        public ActionResult Index()
        {
            UserRepository userRepository = UserRepository.getInstance();

            var userId = User.Identity.GetUserId();

            var user = userRepository.getUser(userId);

            return View(user);
        }

        //
        // GET: /Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Profile/Create
        public ActionResult PasswordChange()
        {
            return View();
        }

        //
        // POST: /Profile/Create
        [HttpPost]
        public ActionResult PasswordChange(PasswordChangeModel passwordChangeModel)
        {
            try
            {
                if (passwordChangeModel.Password == passwordChangeModel.ConfirmPassword)
                {
                    var userManager = AppUserManager.Create(null, HttpContext.GetOwinContext());
                    var authManager = HttpContext.GetOwinContext().Authentication;
                     var userId = User.Identity.GetUserId();

                     var result=userManager.ChangePassword(userId, passwordChangeModel.CurrentPassword, passwordChangeModel.Password);
                    if(result.Succeeded)
                     return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, string.Join(",", result.Errors));
                        return View(passwordChangeModel);
                    }
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Passwords don't match!");
                    return View(passwordChangeModel);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        //
        // GET: /Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
