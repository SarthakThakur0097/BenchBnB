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
        [Required]
        public string Description { get; set; }
        public int NumSeats { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public User User { get; set; }
        public List<Review> Reviews { get; set; }
        
        public Bench()
        {
            Reviews = new List<Review>();

        }
        public Bench (string description, int numSeats, float latitude, float longitude, User user)
        {
            Description = description;
            NumSeats = numSeats;
            Latitude = latitude;
            Longitude = longitude;
            User = user;
        }

        public double? AverageRating
        {
            get
            {
                if (Reviews.Count > 0)
                {
                    return Math.Round(Reviews.Average(r => r.Rating), 1);
                }
                else
                {
                    return null;
                }
            }
        }

        public string ShortDescription
        {
            get
            {
                string description = Description;
                string shortDescription = string.Empty;

                // Make sure that we have a description...
                if (!string.IsNullOrWhiteSpace(description))
                {
                    // Get a collection of the words in the description.
                    var words = description
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // If we have more than 10 words
                    // then take the first 10 and add "..." to the end
                    // otherwise just use the description as is. 
                    if (words.Length > 10)
                    {
                        shortDescription = string.Join(" ", words.Take(10)) + "...";
                    }
                    else
                    {
                        shortDescription = description;
                    }
                }

                return shortDescription;
            }
        }

    }
}