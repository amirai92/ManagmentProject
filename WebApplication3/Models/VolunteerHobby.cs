using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class VolunteerHobby
    {

        [Required(ErrorMessage = "Please enter Language Name")]
        public string LanguageName { get; set; }
        
    }
}