using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Education
    {
        public bool Educ { get; set; }

        public bool Uni { get; set; }
        public string InstituteUniversity { get; set; }
        public string TitleOfDiploma { get; set; }
        public string Degree { get; set; }

        [RegularExpression("^([0-9]{4})$", ErrorMessage = "Enter an Year")]
        public DateTime? UniFromYear { get; set; }
        [RegularExpression("^([0-9]{4})$", ErrorMessage = "Enter an Year")]
        public DateTime? UniToYear { get; set; }

        public bool School { get; set; }
        public string SchoolName { get; set; }
        [RegularExpression("^([0-9]{4})$", ErrorMessage = "Enter an Year")]
        public DateTime? SchoolFromYear { get; set; }
        [RegularExpression("^([0-9]{4})$", ErrorMessage = "Enter an Year")]
        public DateTime? SchoolToYear { get; set; }
 
        public bool Course { get; set; }
        public string CourseName { get; set; }
        [RegularExpression("^([0-9]{4})$", ErrorMessage = "Enter an Year")]
        public DateTime? CourseFromYear { get; set; }


    }
}