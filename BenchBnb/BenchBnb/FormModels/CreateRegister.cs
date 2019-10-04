﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BenchBnb.FormModels
{
    public class CreateRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        //[Required]
        //public string FirstName { get; set; }
        //[Required]
        //public string LastName { get; set; }
    }
}