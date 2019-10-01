using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnb.FormModels
{
    public class CreateReview
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
    }
}