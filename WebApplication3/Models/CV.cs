using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThisAbility.Models
{
    public class CV
    {
        //TODO: continue this
        private static int CVcou;
        [Key]
        public int CVid { get; set; }


        [StringLength(9, ErrorMessage = "ID number must be 9 characters")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "ID number should contain only digits")]
        public string ID { get; set; }





        public CV()
        {
            this.CVid = CVcou++;
        }


    }
}