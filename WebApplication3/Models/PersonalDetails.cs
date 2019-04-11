using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class PersonalDetails
    {

        public int IDPers { get; set; }

        [Required(ErrorMessage = "Please Your First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Your Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Your Date Of Birth ")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Your Nationality ")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Select Your Educational Level ")]
        public string EducationalLevel { get; set; }

        [Required(ErrorMessage = "Please Your Address ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Your Phone Number ")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Please Your Email Address ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Your Summary")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }



    }
}