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
        public string Description { get; set; }
        [Required]
        public int NumSeats { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Bench()
        {

        }
        public Bench (string description, int numSeats, float latitude, float longitude, User user)
        {
            Description = description;
            NumSeats = numSeats;
            Latitude = latitude;
            Longitude = longitude;
            User = user;
        }
    }
}