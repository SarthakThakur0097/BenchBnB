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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var formModel = new CreateReview();

            return View("Create", formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReview formModel)
        {
            var repo = new ReviewsRepo(context);
            try
            {
                var review = new Review(formModel.Rating, formModel.Comment);
                repo.Insert(review);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                //HandleDbUpdateException(ex);
            }

            return View("Create", formModel);
        }
    }
}