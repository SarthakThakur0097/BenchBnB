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
        [Required]
        public float Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BenchId { get; set; }
        public Bench Bench { get; set; }
        public DateTime CreatedOn { get; set; }
        public Review()
        {

        }
        public Review(float rating, string comment, Bench bench, User user)
        {
            Rating = rating;
            Comment = comment;
            Bench = bench;
            User = user;
        }
        
    }
}