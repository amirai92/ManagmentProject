using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.ViewModel
{
    public class VM
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }

        public PersonalDetails Pd { get; set; }
        public Language Langs { get; set; }
        public Education Educ { get; set; }
        public VolunteerHobby VolunteerNhobbies { get; set; }
        public PastJob Jobs { get; set; }
        public Disability Disabilities { get; set; }


    }
}