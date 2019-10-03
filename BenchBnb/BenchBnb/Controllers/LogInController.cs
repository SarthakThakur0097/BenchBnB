﻿using BenchBnb.FormModels;
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

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LogInFormModel();
            return View(viewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogInFormModel formModel)
        {
            var repo = new UserRepo(context);
            try
            {


                if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
                {
                    User user = repo.GetByEmail(formModel.Email);

                    if (user != null || BCrypt.Net.BCrypt.Verify(formModel.Password, formModel.HashedPassword))
                    {
                        return RedirectToAction("Index", "Homepage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName Or Password");
                    }
                    if (ModelState.IsValid)
                        FormsAuthentication.SetAuthCookie(formModel.Email, false);
                }
            }
            catch (DbUpdateException ex)
            {
                //HandleDbUpdateException(ex);
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