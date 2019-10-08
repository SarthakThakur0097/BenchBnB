using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BenchBnb.FormModels
{
    public class CreateBench
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumSeats { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        public float? AverageRating { get; set; }
        public string userTag { get; set; }
        public DateTime CreatedOn {get;set;}
    }
}