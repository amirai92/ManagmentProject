using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Key]
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "User Name must be 3 to 15 characters")]
        private string UserName { get; set; }


        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password must be 3 to 15 characters")]
        private string Password { get; set; }

        public CV cv { get; set; }

        Employee(string UserName,string Password, string FirstName, string LastName)
        {
            this.UserName = UserName;
            //encr?
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            cv = new CV(FirstName,LastName);

        }

    }
}