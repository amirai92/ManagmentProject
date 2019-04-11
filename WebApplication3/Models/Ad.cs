using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public abstract class Ad
    {

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 2 to 15 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^(05[0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }

        public bool Intellectual { get; set; }
        public bool Physical { get; set; }
        public bool MentalIllness { get; set; }
        public bool Sensory { get; set; }


    }
}