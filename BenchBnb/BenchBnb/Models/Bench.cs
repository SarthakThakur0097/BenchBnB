using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BenchBnb.Models
{
    public class Bench
    {
        public int Id { get; set; }
        [Required, Column("Description")]
        public string Description { get; set;}
        [Required, Column("NumSeats")]
        public int NumSeats { get; set; }
        [Required, Column("Latitude")]
        public float Latitude { get; set; }
        [Required, Column("Longitude")]
        public float Longitude { get; set; } 

        public Bench (string description, int numSeats, float latitude, float longitude)
        {
            Description = description;
            NumSeats = numSeats;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}