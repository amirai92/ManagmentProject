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
        public int cvId { get; set; }

        public string id { get; set; }

        public int Langs { get; set; }

        public int Educ { get; set; }

        public int VolunteerNhobbies { get; set; }

        public int Jobs { get; set; }

        public int Disabilities { get; set; }

        public CV()
        {
            this.cvId = idcou++;
        }
    }
        

    
}