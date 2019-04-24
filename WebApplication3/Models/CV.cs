using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class CV
    {

        public PersonalDetails pd { get; set; }

        public Language langs { get; set; }

        public Education educ { get; set; }

        public VolunteerHobby volunteerNhobbies { get; set; }

        public PastJob jobs { get; set; }

        public Disability disabilities { get; set; }



    }
        


    
}