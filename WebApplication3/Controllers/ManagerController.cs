using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThisAbility.Dal;
using WebApplication3.Models;

namespace ThisAbility.Controllers
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
            List<Employer> userToCheck = (from x in dal.employers
                                          where (x.UserName == man.UserName) && (x.Password == man.Password)
                                          select x).ToList<Employer>();       //Attempting to get user information from database
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
    }
}