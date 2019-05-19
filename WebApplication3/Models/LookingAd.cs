using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApplication3.Models.Enums;
namespace WebApplication3.Models
{

    public class LookingAd : Ad
    {

        public String Cv { get; set; }

        public LookingAd() { }

        public LookingAd(String id, String firstname, String lastname, string mail, string phone,
            bool interl, bool phys, bool mental, bool sens, String cv)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
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