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
    public class RegisterController : Controller
    {
        private Context context;

        public RegisterController()
        {
            context = new Context();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new RegisterFormModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterFormModel formModel)
        {
            if (ModelState.IsValid)
            {
                // Create an instance of the user database model.
                User user = new User()
                {
                    Email = formModel.Email,
                    HashedPassword = formModel.Password,
                    Name = formModel.Name
                };
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(formModel.Password, 12);
                user.HashedPassword = hashedPassword;
                // TODO Save the user to the database.
                var userRepo = new UserRepo(context);
                try
                {
                    userRepo.Insert(user);
                    FormsAuthentication.SetAuthCookie(formModel.Email, false);

                    // Redirect the user to the "Home" page.
                    return RedirectToAction("Index", "Bench");
                }
                catch(DbUpdateException db)
                {

                    ModelState.AddModelError("", "Email is already in use.");
                }
                
            }

            return View(formModel);
        }

    }
}