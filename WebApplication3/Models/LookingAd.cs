using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApplication3.Models.Enums;
namespace WebApplication3.Models
{

    public class LookingAd : Ad
    {

        public CV Cv { get; set; }


        public LookingAd(String name, string mail, string phone,
            bool interl, bool phys, bool mental, bool sens, CV cv)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = mail;
            this.Intellectual = interl;
            this.MentalIllness = mental;
            this.Sensory = sens;
            this.Physical = phys;
            this.Cv = cv;


        }
    }
}