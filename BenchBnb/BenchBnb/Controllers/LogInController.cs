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
                if (ModelState.IsValid)
                {
                    User user = repo.GetByPassword(formModel.Password);
                    if (user != null)
                    {
                        return RedirectToAction("Index", "Homepage");
                    }
                    FormsAuthentication.SetAuthCookie(formModel.Email, false);
                }
            }
            catch (DbUpdateException ex)
            {
                //HandleDbUpdateException(ex);
            }

            return View(formModel);
        }
    }
}