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
    public class ReviewController : Controller
    {
        // GET: Review
        private Context context;

        public ReviewController()
        {
            context = new Context();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var formModel = new CreateReview();

            return View("Create", formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReview formModel, int Id)
        {
            var email = User.Identity.Name;

            var revRepo = new ReviewsRepo(context);
            var benRepo = new BenchRepo(context);
            var userRepo = new UserRepo(context);
            try
            {
                Bench bench = benRepo.GetById(Id);
                User user = userRepo.GetByEmail(email);
                var review = new Review(formModel.Rating, formModel.Comment, bench, user);
                revRepo.Insert(review);
                return RedirectToAction("Index", "Bench");
            }
            catch (DbUpdateException ex)
            {
                //HandleDbUpdateException(ex);
            }

            return View("Create", formModel);
        }
    }
}