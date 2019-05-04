using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class VolunteerHobby
    {
        [Key]
        public int id { get; set; }
        public static int count { get; set; }

        public bool Volunteer { get; set; }
        public string VolunteerDet { get; set; }

        public bool Hobbies { get; set; }
        public string HobbiesDet { get; set; }
        public VolunteerHobby()
        {
            this.id = count++;
        }
    }
}