using BenchBnb.FormModels;
using BenchBnb.Models;
using BenchBnb.Models.Data;
using BenchBnb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BenchBnb.Controllers
{
    public class LogInController : Controller
    {
        private Context context;

        public LogInController()
        {
            context = new Context();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LogInFormModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInFormModel formModel)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                // TODO Get the user record from the database by their email.
                var userRepo = new UserRepo(context);

                User user = userRepo.GetByEmail(formModel.Email);

                // If we didn't get a user back from the database
                // or if the provided password doesn't match the password stored in the database
                // then login failed.
                if (user == null || !BCrypt.Net.BCrypt.Verify(formModel.Password, user.HashedPassword))
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }

            if (ModelState.IsValid)
            {
                // Login the user.
                FormsAuthentication.SetAuthCookie(formModel.Email, false);

                // Send them to the home page.
                return RedirectToAction("Index", "Bench");
            }

            return View(formModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}