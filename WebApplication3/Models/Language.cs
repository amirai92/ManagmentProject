using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Language
    {

        [Required(ErrorMessage = "Please enter Language Name")]
        public string LanguageName { get; set; }

        [Required(ErrorMessage = "Please select Proficiency")]
        public string Proficiency { get; set; }

    }
}