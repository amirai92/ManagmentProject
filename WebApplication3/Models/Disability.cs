using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Disability
    {
        [Key]
        public int id { get; set; }
        public static int count { get; set; }


        public bool Disabilities { get; set; }

        public bool Vision { get; set; }
        public string VisionExp { get; set; }

        public bool Hearing { get; set; }
        public string HearingExp { get; set; }

        public bool Learning { get; set; }
        public string LearningExp { get; set; }

        public bool Movment { get; set; }
        public string MovmentExp { get; set; }

        public bool MentalHealth { get; set; }
        public string MentalHealthExp { get; set; }

        public bool Communicating { get; set; }
        public string CommunicatingExp { get; set; }

        public bool Social { get; set; }
        public string SocialExp { get; set; }

        public Disability()
        {
            this.id = count++;
        }
    }
}