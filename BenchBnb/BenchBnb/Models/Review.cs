using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnb.Models
{
    public class Review
    {
        public int Id { get; set; }
        float Rating { get; set; }
        string Comment { get; set; }
    }
}