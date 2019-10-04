using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnb.FormModels
{
    public class BenchDetails
    {
        public string Description { get; }
        public int NumSeats { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float AverageRating { get; set; }
    }
}