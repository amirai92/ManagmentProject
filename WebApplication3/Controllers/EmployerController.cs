﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult EmployerSignUp(Employer emp)
        {
            if (ModelState.IsValid)
            {
                if (!userExists(emp.UserName))
                {
                    DataLayer dal = new DataLayer();
                    emp.role = "Employer";
                    dal.employers.Add(emp);
                    dal.SaveChanges();
                    return View("EmployerMenu", emp);
                }
                else
                    ViewBag.message = "Username Exists in database.";
            }
            else
                ViewBag.message = "Error in registration.";

             return View("EmployerSignUp", emp);
            
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
        public ActionResult Login(Employer emp)
        {

            DataLayer dal = new DataLayer();
            List<Employer> userToCheck = (from x in dal.employers
                                          where (x.UserName == emp.UserName) && (x.Password == emp.Password)
                                          select x).ToList<Employer>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {
                var authTicket = new FormsAuthenticationTicket(
                     1,                                  // version
                     emp.UserName,                      // user name
                     DateTime.Now,                       // created
                     DateTime.Now.AddMinutes(20),        // expires
                     true,       //keep me connected
                     userToCheck[0].role                       // store roles
                     );

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);
                return View("EmployerMenu", emp);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/Password";
                return View("EmployerLogin", emp);
            }
        }
        /*This function handles signing out*/
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EmployerMenu(Employer emp)
        {
            return View(emp);
        }
        public ActionResult Boards(Employer emp)
        {
            return View(emp);
        }
        public ActionResult PublishOnWeb()
        {
            return View();
        }
        public ActionResult WatchingContent()
        {
            return View();
        }
        public ActionResult WatchingTheBoard()
        {
            return View();
        }
        public ActionResult WantedBoard()
        {
            return View(new WantedAd("123456", "sali", "dalal", "sali@ac.com", "0506502199", "blabla", true, true, false, false));

        }

        public ActionResult LookingBoard()
        {
            return View(new LookingAd("123456", "sali", "dalal", "sali@ac.com", "0506502199", true, true, false, false, "1"));

        }
    }
}