using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class PersonalDetails
    {

        [StringLength(9, ErrorMessage = "ID number must be 9 characters")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "ID number should contain only digits")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Please Your First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Your Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Your Date Of Birth ")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }


        [Required(ErrorMessage = "Please Your Address ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Your Phone Number ")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Please Your Email Address ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Your skills")]
        [DataType(DataType.MultilineText)]
        public string skills { get; set; }

        [Required(ErrorMessage = "Please Your Summary")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }



    }
}