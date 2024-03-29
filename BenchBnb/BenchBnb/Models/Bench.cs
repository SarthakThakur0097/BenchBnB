﻿using System;
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
        [Required]
        public string Description { get; set; }
        public int NumSeats { get; set; }
        public float Latitude { get; set; }
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