using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ManagerLogin()
        {
            Manager man = new Manager();
            ViewBag.UserLoginMessage = "";
            return View(man);
        }

        public ActionResult Login(Manager man)
        {

            DataLayer dal = new DataLayer();
            //Encryption enc = new Encryption();
            List<Manager> userToCheck = (from x in dal.managers
                                          where (x.UserName == man.UserName) && (x.Password == man.Password)
                                          select x).ToList<Manager>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {

                return View("loggedin", man);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("ManagerLogin", man);
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

    }
}