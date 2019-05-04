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

        public static int idcou=0;

        [Key]
        public int id { get; set; }
        public virtual PersonalDetails Pd { get; set; }

        public virtual Language Langs { get; set; }

        public virtual Education Educ { get; set; }

        public virtual VolunteerHobby VolunteerNhobbies { get; set; }

        public virtual PastJob Jobs { get; set; }

        public virtual Disability Disabilities { get; set; }

        public CV()
        {
            this.id = idcou++;
        }
    }
        

    
}