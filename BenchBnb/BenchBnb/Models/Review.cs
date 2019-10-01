using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BenchBnb.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required, Column("Rating")]
        public float Rating { get; set; }
        [Required, Column("Comment")]
        public string Comment { get; set; }

        public Review(float rating, string comment)
        {
            Rating = rating;
            Comment = comment;
        }
        
    }
}