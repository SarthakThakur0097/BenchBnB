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
        async public Task<IHttpActionResult> Get()
        {
            List<Bench> benches = await bRepo.GetBenches();
            var flattendBenches = benches.Select(b => new
            {
                BenchId = b.Id,
                Description = b.ShortDescription,
                NumSeats = b.NumSeats,
                Latitude = b.Latitude,
                Longitude = b.Longitude,
                HasReviews = b.Reviews.Count > 0,
                AverageRating = b.AverageRating,
                UserDisplayName = b.User.Name
            }).ToList();

            return Ok(flattendBenches);
        }
    }
}