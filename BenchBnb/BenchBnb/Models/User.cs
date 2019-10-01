using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BenchBnb.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, Column("UserName")]
        public string UserName { get; set; }
        [Required, Column("Password")]
        public string Password { get; set; }

        public User()
        {

        }
        public User(string userName, string passWord)
        {
            UserName = userName;
            Password = passWord;
        }
    }
}