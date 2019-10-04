using BenchBnb.Models;
using BenchBnb.Models.Data;
using BenchBnb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace BenchBnb.Controllers
{
    [RoutePrefix("api/benches")]
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
        [Route("")]
        async public Task<List<Bench>> Get()
        {
            List<Bench> benches = await bRepo.GetBenches();
            return benches;
        }
    }
}