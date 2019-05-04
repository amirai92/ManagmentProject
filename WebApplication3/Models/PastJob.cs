using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PastJob
    {
        [Key]
        public int id { get; set; }
        public static int count { get; set; }

        public bool pastjobs { get; set; }
        public bool pastJob1 { get; set; }
        public string title1 { get; set; }
        public string explain1 { get; set; }

        public bool pastJob2 { get; set; }
        public string title2 { get; set; }
        public string explain2 { get; set; }

        public bool pastJob3 { get; set; }
        public string title3 { get; set; }
        public string explain3 { get; set; }
        public PastJob()
        {
            this.id = count++;
        }
    }
}