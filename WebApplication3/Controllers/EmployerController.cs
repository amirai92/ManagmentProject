using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployerController : Controller
    {
        // GET: Employer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployerLogin()
        {
            Employer emp = new Employer();
            ViewBag.UserLoginMessage = "";
            return View(emp);
        }

        public ActionResult Login(Employer emp)
        {

            DataLayer dal = new DataLayer();
            //Encryption enc = new Encryption();
            List<Employer> userToCheck = (from x in dal.employers
                                          where (x.UserName == emp.UserName) && (x.Password == emp.Password)
                                          select x).ToList<Employer>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {

                return View("loggedin", emp);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("EmployerLogin", emp);
            }
        }


        public ActionResult WantedBoard()
        {
            return View(new WantedAd("sali", "sali@ac.com", "0506502199", "blabla", true, true, false, false));

        }

        public ActionResult LookingBoard()
        {
            return View(new LookingAd("sali", "sali@ac.com", "0506502199", true, true, false, false, null));

        }

        public ActionResult EmployerSignup()
        {
            return View();
        }
    }
}