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
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid ID Number")]
        public string ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Key]
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "User Name must be 3 to 15 characters")]
        public string UserName { get; set; }


        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Password must be 3 to 15 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(05[0-9]{8})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }


        public string Cv { get; set; }


        [Required]
        public string role { get; set; }

        public Employee() { }

        public Employee(string UserName,string Password, string FirstName, string LastName)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Cv = "0";
        }

    }
}