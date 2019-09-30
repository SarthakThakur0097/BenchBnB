using BenchBnb.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}