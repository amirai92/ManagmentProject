using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class WantedAd : Ad
    {

        public string Description { get; set; }

        public WantedAd() { }

        public WantedAd(String id, String firstname, String lastname, string mail, string phone, string desc)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = LastName;
            this.Phone = phone;
            this.Email = mail;
            this.Description = desc;
        }


    }
}