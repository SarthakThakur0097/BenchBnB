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

namespace BenchBnb.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        private Context context; 

        public HomepageController()
        {
            context = new Context();
        }


        [HttpGet]
        public ActionResult Create()
        {
            var formModel = new CreateBench();
      
            return View("Create", formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBench formModel)
        {
            var repo = new BenchRepo(context);
            try
            {
                var bench = new Bench("Test", formModel.NumSeats, 4.534f, 5.493f);
                repo.Insert(bench);
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