using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Education
    {

        [Required(ErrorMessage = "Please Your Institute or university")]  
        public string InstituteUniversity { get; set; }

        [Required(ErrorMessage = "Please Your Title of diploma")]
        public string TitleOfDiploma { get; set; }

        [Required(ErrorMessage = "Please Your Degree")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Please enter Start Year")]
        public Nullable<System.DateTime> FromYear { get; set; }

        [Required(ErrorMessage = "Please enter End Year")]
        public Nullable<System.DateTime> ToYear { get; set; }


    }
}