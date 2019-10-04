using BenchBnb.FormModels;
using BenchBnb.Models.Data;
using BenchBnb.Models;
using BenchBnb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Web.Script.Serialization;

namespace BenchBnb.Controllers
{
    
    public class BenchController : Controller
    {
        // GET: Homepage
        private Context context; 

        public BenchController()
        {
            context = new Context();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(float? lat, float? lon)
        {
            var formModel = new CreateBench();
            if(lat!=null)
            {
                formModel.Latitude = lat.Value;
                formModel.Longitude = lon.Value;
            }
            return View("Create", formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(CreateBench formModel)
        {
            var repo = new BenchRepo(context);
            var userRepo = new UserRepo(context);
            try
            {
                User user = userRepo.GetByEmail(User.Identity.Name);
                var bench = new Bench(formModel.Description, formModel.NumSeats, formModel.Latitude, formModel.Longitude, user);
                repo.Insert(bench);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                //HandleDbUpdateException(ex);
            }
            return View("Create", formModel);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var repo = new BenchRepo(context);
            IList<Bench> benches = repo.GetAllBenches();
            var json = new JavaScriptSerializer().Serialize(benches);

            return View("Index", benches);
        }

        public ActionResult Details(int benchId)
        {
            var formModel = new CreateBench();
            var benchRepo = new BenchRepo(context);
            var reviewRepo = new ReviewsRepo(context);
            Bench bench = benchRepo.GetById(benchId);
            formModel.Description = bench.Description;
            formModel.NumSeats = bench.NumSeats;
            formModel.Latitude = bench.Latitude;
            formModel.Longitude = bench.Longitude;
            IList<Review> allReviews = reviewRepo.GetAllReviewsById(benchId);
            if (allReviews.Count == 0)
            {
                formModel.AverageRating = null;
            }
            else
            {
                float sum = 0f;
                foreach (Review rev in allReviews)
                {
                    sum += rev.Rating;
                }
                sum /= allReviews.Count;
                formModel.AverageRating = sum;
            }

            return View(formModel);
        }

        [HttpPost]
        public ActionResult Details(CreateBench formModel)
        { 
            return View(formModel);
        }

    }
}