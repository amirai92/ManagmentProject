using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Statistics()
        {
            return View();
        }
        public ActionResult Watch()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult ManagerMenu()
        {
            return View();
        }
        /*This function redirects to user register page*/
        public ActionResult ManagerRegister()
        {
            Manager user = new Manager();
            ViewBag.UserLoginError = "";
            return View(user);
        }

        /*This function adds new user to database*/
        /*Given user information from user register form*/
        public ActionResult AddManager(Manager mng)
        {
            DataLayer dal = new DataLayer();

            if (ModelState.IsValid)
            {
                if (!userExists(mng.UserName))     //Adding user to database
                {
                    //mng.Password = hashedPassword;
                    dal.managers.Add(mng);
                    dal.SaveChanges();
                    ViewBag.message = "Manager was added succesfully.";
                    mng = new Manager();
                }
                else
                    ViewBag.message = "Username Exists in database.";
            }
            else
                ViewBag.message = "Error in registration.";
            return View("ManagerRegister", mng);
        }

        /*This function compares given username with usernames in database*/
        private bool userExists(string userName)
        {
            DataLayer dal = new DataLayer();
            List<Manager> users = dal.managers.ToList<Manager>();
            foreach (Manager manager in dal.managers)
                if (manager.UserName.Equals(userName))
                    return true;
            return false;
        }



        /*This function handles signing out*/
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
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
            List<Manager> userToCheck = (from x in dal.managers
                                         where (x.UserName == man.UserName) && (x.Password == man.Password)
                                         select x).ToList<Manager>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {
                ViewBag.UserLoginMessage = "You have logged succesfully";
                return View("ManagerMenu", man);
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