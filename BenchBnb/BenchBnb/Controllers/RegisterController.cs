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
            var viewModel = new CreateRegister();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(CreateRegister formModel)
        {
            if (ModelState.IsValid)
            {
                var repo = new UserRepo(context);
                try
                {
                    var user = new User(formModel.Email, formModel.Password);
                    repo.Insert(user);
                    return RedirectToAction("Login", "LogIn");
                }
                catch (DbUpdateException ex)
                {
                    //HandleDbUpdateException(ex);
                }
            }

                //FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Register", "Register");
        }

    }
}