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
            try
            {
                var bench = new Bench(formModel.Description, formModel.NumSeats, formModel.Latitude, formModel.Longitude);
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

    }
}