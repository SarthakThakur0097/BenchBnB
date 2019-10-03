using BenchBnb.Models;
using BenchBnb.Models.Data;
using BenchBnb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BenchBnb.Controllers
{
    [System.Web.Http.RoutePrefix("api/benches")]
    public class BenchAPIController : ApiController
    {
        BenchRepo bRepo;
        Context context;
        public BenchAPIController()
        {
            context = new Context();
            bRepo = new BenchRepo(context);
        }
        // GET: BenchAPI
        [System.Web.Http.Route("")]
        async public Task<List<Bench>> Get()
        {
            List<Bench> benches = await bRepo.GetBenches();
            return benches;
        }
    }
}