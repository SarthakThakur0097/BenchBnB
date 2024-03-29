﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnb.FormModels
{
    public class CreateBench
    {
        public string Description { get; set; }
        public int NumSeats { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float? AverageRating { get; set; }
        public string userTag { get; set; }
        public DateTime CreatedOn {get;set;}
    }
}