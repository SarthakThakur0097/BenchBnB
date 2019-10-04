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
using System.Text;
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
        [Authorize]
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
            var userRepo = new UserRepo(context);

            Bench bench = benchRepo.GetById(benchId);
            User user = userRepo.GetById(bench.UserId);


            string phrase = user.Name;
            string[] names = phrase.Split(' ');
            string lastName = names[1];
            StringBuilder uTag = new StringBuilder(names[0]);
            uTag.Append(" " + lastName[0]);
            formModel.userTag = uTag.ToString();
            
            //string name = user.Name;
            //StringBuilder firstName = new StringBuilder();
            //StringBuilder lastInit = new StringBuilder();
            //bool enterLast = false;
            //for(int i = 0; i<name.Length; i++)
            //{
            //    if (name[i]==' ')
            //    {
            //        firstName.Append(' ');
            //    }
            //    else if(name[i]!=' ')
            //    {
            //        firstName.Append(name[i]);
            //    }
            //} 
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
            string desc = formModel.Description;
            StringBuilder sb = new StringBuilder();
            
            int wordCount = 0;
            for(int i = 0; i<desc.Length; i++)
            {
                sb.Append(desc[i]);
                if(desc[i]== ' ')
                {
                    wordCount++;
                }
                if(wordCount==10)
                {
                    sb.Append("...");
                    break;
                }
            }
            formModel.Description = sb.ToString();
            
            return View(formModel);
        }

        [HttpPost]
        public ActionResult Details(CreateBench formModel)
        { 
            return View(formModel);
        }

    }
}