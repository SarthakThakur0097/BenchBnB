using BenchBnb.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace BenchBnb.Models.Repositories
{
    public class BenchRepo
    {
        private Context _context;

        public BenchRepo(Context context)
        {
            _context = context;
        }

        //Leaving this commented for the time being to make sure the code doesn't break by removing this
        [Obsolete]
        public IList<Bench> GetAllBenches()
        {
            return _context.Benches.ToList();
        }

        public Bench GetById(int id)
        {
            return _context.Benches.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Bench bench)
        {
            _context.Benches.Add(bench);
            _context.SaveChanges();
        }

        public void Update(Bench bench)
        {
            _context.Benches.Attach(bench);
            _context.Entry(bench).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        async public Task<List<Bench>> GetBenches()
        {
            using (var context = new Context())
            {
                List<Bench> benches = await context.Benches
                  .Include(b => b.Reviews)
                  .Include(b => b.User)
                  .OrderBy(b => b.NumSeats)
                  .ToListAsync();

                return benches;
            }
        }
    }
}