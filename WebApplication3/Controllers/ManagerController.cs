﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            DataLayer dal = new DataLayer();
            int countEmployee = 0,countEmployer=0,countManager=0,countSigned=0;
            foreach (Employee employee in dal.employees)
            {
                countEmployee++;
            }
            foreach (Employer employer in dal.employers)
            {
                countEmployer++;
            }
            foreach (Manager manager in dal.managers)
            {
                countManager++;
            }

            ViewBag.countEmp = countEmployee;
            ViewBag.countEmpr = countEmployer;
            ViewBag.countMan = countManager;
            countSigned = countEmployee + countEmployer + countManager;
            ViewBag.countSign = countSigned;       
            return View();
        }
        public ActionResult Watch()
        {
            return View();
        }
        public ActionResult Boards(Manager mng)
        {
            return View(mng);
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult ManagerMenu(Manager mng)
        {
            return View(mng);
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
                    mng.role = "Manager";
                    dal.managers.Add(mng);
                    dal.SaveChanges();
                    ViewBag.message = "Manager was added succesfully.";
                    mng = new Manager();
                    View("ManagerMenu", mng);
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
                var authTicket = new FormsAuthenticationTicket(
                     1,                                  // version
                     man.UserName,                      // user name
                     DateTime.Now,                       // created
                     DateTime.Now.AddMinutes(20),        // expires
                     true,       //keep me connected
                     userToCheck[0].role                       // store roles
                     );

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);
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


        //QA eddit 


        public ActionResult QAedittor()
        {
            using (DataLayer DBQA = new DataLayer())
            {
                return View(DBQA.QA.ToList());
            }
        }

        // GET: Content/Details/5
        public ActionResult Details(string id)
        {
            using (DataLayer DBQA = new DataLayer())
            {
                return View(DBQA.QA.Where(x => x.InfoContent == id).FirstOrDefault());
            }
        }

        // GET: Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Content/Create
        [HttpPost]
        public ActionResult Create(QA qa)
        {
            try
            {
                using (DataLayer DBQA = new DataLayer())
                {
                    DBQA.QA.Add(qa);
                    DBQA.SaveChanges();

                }
                // TODO: Add insert logic here

                return RedirectToAction("QAedittor");
            }
            catch
            {
                return View();
            }
        }

        // GET: Content/Edit/5
        [NonAction]
        public ActionResult Edit(string id)
        {
            using (DataLayer DBQA = new DataLayer())
            {
                return View(DBQA.QA.Where(x => x.InfoContent == id).FirstOrDefault());
            }
        }


        // POST: Content/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, QA qa)
        {
            try
            {
                using (DataLayer DBQA = new DataLayer())
                {
                    DBQA.Entry(qa).State = EntityState.Modified;
                    DBQA.SaveChanges();
                }

                return RedirectToAction("QAedittor");
            }
            catch
            {
                return View();
            }
        }

   

        // GET: Content/Delete/5
        public ActionResult Delete(string id)
        {
            using (DataLayer DBQA = new DataLayer())
            {
                return View(DBQA.QA.Where(x => x.InfoContent == id).FirstOrDefault());
            }
        }

        // POST: Content/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                using (DataLayer DBQA = new DataLayer())
                {
                    QA qa = DBQA.QA.Where(x => x.InfoContent == id).FirstOrDefault();
                    DBQA.QA.Remove(qa);
                    DBQA.SaveChanges();

                }
                // TODO: Add delete logic here

                return RedirectToAction("QAedittor");
            }
            catch
            {
                return View();
            }
        }


    }
}