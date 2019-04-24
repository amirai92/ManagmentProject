using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Education
    {
        public bool education { get; set; }

        public bool uni { get; set; }
        public string InstituteUniversity { get; set; }
        public string TitleOfDiploma { get; set; }
        public string Degree { get; set; }
        public DateTime? UniFromYear { get; set; }
        public DateTime? UniToYear { get; set; }

        public bool School { get; set; }
        public string SchoolName { get; set; }
        public DateTime? SchoolFromYear { get; set; }
        public DateTime? SchoolToYear { get; set; }
        public int Years { get { return SchoolFromYear.Value.Year - SchoolToYear.Value.Year; }
                           set { Years = SchoolFromYear.Value.Year - SchoolToYear.Value.Year; } }

        public bool Course { get; set; }
        public string CourseName { get; set; }
        public DateTime? CourseFromYear { get; set; }


    }
}