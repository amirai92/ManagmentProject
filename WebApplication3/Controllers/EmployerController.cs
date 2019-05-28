using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Dal;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    public class EmployerController : Controller
    {
        public static VM vm;

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
                    DataLayerCS(emp);
                    return View("EmployerLogin");
                }
                else
                    ViewBag.message = "Username Exists in database.";
            }
            else
                ViewBag.message = "Error in registration.";

             return View("EmployerSignUp", emp);
            
        }

        private static void DataLayerCS(Employer emp)
        {
            DataLayer dal = new DataLayer();
            emp.role = "Employer";
            dal.employers.Add(emp);
            dal.SaveChanges();
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
            List<Employer> userToCheck = CheckEmployer(emp);//Attempting to get user information from database
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

                Session["user"] = emp.UserName;
                Session["title"] = "employer";

                return View("EmployerMenu", emp);
            }
            else
            {
                Session["user"] = null;
                ViewBag.UserLoginMessage = "Incorrect Username/Password";
                return View("EmployerLogin", emp);
            }
        }

        private static List<Employer> CheckEmployer(Employer emp)
        {
            DataLayer dal = new DataLayer();
            List<Employer> userToCheck = (from x in dal.employers
                                          where (x.UserName == emp.UserName) && (x.Password == emp.Password)
                                          select x).ToList<Employer>();
            return userToCheck;
        }

        /*This function handles signing out*/
        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session["title"] = null;
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
            DataLayer dal = new DataLayer();

            List<WantedAd> wantedAd = (from x in dal.wantedAd
                                         select x).ToList<WantedAd>();
            vm = new VM()
            {
                WantedAds = wantedAd
            };
            return View(vm);
        }

        public ActionResult LookingBoard()
        {
            DataLayer dal = new DataLayer();

            List<LookingAd> lookingAd = (from x in dal.lookingAd
                                         select x).ToList<LookingAd>();
            vm = new VM()
            {
                LookingAds = lookingAd
            };
            return View(vm);
        }

        public ActionResult WantedPublish(WantedAd wntAd)
        {
            bool flag = false;
            TempData["alertMessage"] = null;

            DataLayer dal = new DataLayer();

            string str = Session["user"].ToString();

            Employer emp = (from x in dal.employers
                            where str == x.UserName
                            select x).ToList<Employer>()[0];

            //check if there already is a wanted ad for this user
            List<WantedAd> ads = dal.wantedAd.ToList<WantedAd>();
            foreach (WantedAd wanted in dal.wantedAd)
                if (wanted.ID.Equals(emp.ID))
                {
                    TempData["alertMessage"] = "You have already posted a wanted ad";
                    flag = true;
                }
                else
                {
                    TempData["alertMessage"] = "Your ad was posted successfuly";
                    flag = false;
                }

            if (!flag)
            {
                if (ModelState.IsValid)
                {
                    wntAd.FirstName = emp.FirstName;
                    wntAd.LastName = emp.LastName;
                    wntAd.ID = emp.ID;
                    wntAd.Phone = emp.Phone;
                    wntAd.Email = emp.Email;

                    dal.wantedAd.Add(wntAd);
                    dal.SaveChanges();
                    ViewBag.message = "Wanted ad was published succesfully.";

                    return View();
                }
                else
                {
                    ViewBag.message = "Error in ad publishment.";
                }
            }
            else
                return RedirectToAction("EmployerMenu");

            return View();
        }

        public ActionResult Desc(WantedAd desc)
        {
            DataLayer dal = new DataLayer();

            string str = Session["user"].ToString();

            Employer emp = (from x in dal.employers
                            where str == x.UserName
                            select x).ToList<Employer>()[0];

            WantedAd wnt = (from x in dal.wantedAd
                            where x.ID == emp.ID
                            select x).ToList<WantedAd>()[0];

            wnt.Description = desc.Description;
            dal.SaveChanges();

            TempData["alertMessage"] = "Your ad was posted successfuly";

            return RedirectToAction("EmployerMenu");
        }

        public ActionResult QAview()
        {
            using (DataLayer DBQA = new DataLayer())
            {
                return View(DBQA.QA.ToList());
            }
        }

    }
}