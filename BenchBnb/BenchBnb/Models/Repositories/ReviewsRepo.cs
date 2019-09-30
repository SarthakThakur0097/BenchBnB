﻿using BenchBnb.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnb.Models.Repositories
{
    public class ReviewsRepo
    {
        private Context _context;

        public ReviewsRepo(Context context)
        {
            _context = context;
        }

        public IList<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();

        }

        public Review GetById(int id)
        {
            return _context.Reviews.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Update(Review review)
        {
            _context.Reviews.Attach(review);
            _context.Entry(review).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}