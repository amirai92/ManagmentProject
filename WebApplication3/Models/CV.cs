using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CV
    {
        //TODO: continue this
        private static int CVcou;
        [Key]
        public int CVid { get; set; }
        

        public PersonalDetails pd { get; set; }

        public bool language { get; set; }
        public Language[] lang { get; set; }

        public bool education { get; set; }
        public Education[] educ { get; set; }

        public bool volunteerNhobbies { get; set; }
        public VolunteerHobby[] vNh { get; set; }

        public bool army { get; set; }
        public Army arm { get; set; }

        public bool pastJobs { get; set; }
        public PastJob[] jobs { get; set; }

        public bool disabilities { get; set; }
        public Disability[] disa { get; set; }

        [StringLength(9, ErrorMessage = "ID number must be 9 characters")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "ID number should contain only digits")]
        public string ID { get; set; }





        public CV(string first, string last)
        {
            this.CVid = CVcou++;
            pd = new PersonalDetails();
            pd.FirstName = first;
            pd.LastName = last;
        }


    }
}