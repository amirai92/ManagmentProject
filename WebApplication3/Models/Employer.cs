using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Employer
    {
        [Required]
        public string ID { get; set; }

        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }


        [Required]
        public string role { get; set; }
    }
}