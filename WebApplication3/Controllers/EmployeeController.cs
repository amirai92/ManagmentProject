using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Dal;
using System.Web.Security;
using WebApplication3.ViewModel;
using System.Web;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        public static VM vm;

        // GET: User
        public ActionResult DefaultLoad()
        {
            Employee defUser = new Employee("Amir", "123456", "Amir", "Aizin");
            return View("EmployeeMenu", defUser);
        }
        public ActionResult EmployeeMenu(Employee emp)
        {
            return View(emp);
        }

        public ActionResult WatchingContent()
        {
            return View();
        }
        public ActionResult WatchingTheBoard(Employee emp)
        {
            return View(emp);
        }
        /*This function handles signing out*/
        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session["title"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult enterSignUp()
        {
            Employee obj = new Employee();
            return View("EmployeeSignUp", obj);
        }

        public ActionResult EmployeeSignUp(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (!userExists(emp.UserName))
                {
                    DataLayerCS(emp);
                    ViewBag.message = "Employee was added succesfully.";
                    return View("EmployeeLogin");
                }
                else
                {
                    ViewBag.message = "Username Exists in database.";
                }
            }
            else
            {
                ViewBag.message = "Error in registration.";
            }
            return View("EmployeeSignUp", emp);

        }

        private static void DataLayerCS(Employee emp)
        {
            DataLayer dal = new DataLayer();
            emp.role = "Employee";
            dal.employees.Add(emp);
            dal.SaveChanges();
        }

        /*This function compares given username with usernames in database*/
        private bool userExists(string userName)
        {
            DataLayer dal = new DataLayer();
            List<Employee> users = dal.employees.ToList<Employee>();
            foreach (Employee employee in dal.employees)
                if (employee.UserName.Equals(userName))
                    return true;
            return false;
        }
        public ActionResult EmployeeLogin()
        {
            Employee user = new Employee();
            ViewBag.UserLoginMessage = "";
            return View(user);
        }

        public ActionResult Login(Employee emp)
        {

            DataLayer dal = new DataLayer();
            //Encryption enc = new Encryption();
            List<Employee> userToCheck = EmpToCheck(emp, dal);//Attempting to get user information from database
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
                Session["title"] = "employee";

                return View("EmployeeMenu", emp);
            }

            else
            {
                Session["user"] = null;
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("EmployeeLogin", emp);
            }
        }

        private static List<Employee> EmpToCheck(Employee emp, DataLayer dal)
        {
            return (from x in dal.employees
                    where (x.UserName == emp.UserName) && (x.Password == emp.Password)
                    select x).ToList<Employee>();
        }

        public ActionResult WantedBoard()
        {
            String str = Session["user"].ToString();

            DataLayer dal = new DataLayer();

            List<WantedAd> wantedAd = (from x in dal.wantedAd
                                       select x).ToList<WantedAd>();

            List<Employee> emp = (from x in dal.employees where str == x.UserName
                                       select x ).ToList<Employee>();
            vm = new VM()

            {
                WantedAds = wantedAd,
                Employee = emp[0]
            };
            return View(vm);
        }

        public ActionResult LookingBoard()
        {
            String str = Session["user"].ToString();
            DataLayer dal = new DataLayer();

            List<LookingAd> lookingAd = (from x in dal.lookingAd
                                         select x).ToList<LookingAd>();
            List<Employee> emp = (from x in dal.employees
                                  where str == x.UserName
                                  select x).ToList<Employee>();
            vm = new VM()
            {
                LookingAds = lookingAd,
                Employee = emp[0]
            };
            return View(vm);
        }

        public ActionResult CreateCV(Employee emp)
        {
            vm = new VM
            {
                Employee = emp,
                Pd = new PersonalDetails()
            };

            return View(vm);
        }

        public ActionResult UpdateLang(VM p)
        {
            /*
            if (ModelState.IsValid)
            {
                    DataLayer dal = new DataLayer();
                    dal.personalDetails.Add(p.Pd);
                    dal.SaveChanges();
                    ViewBag.message = "Employee was added succesfully.";
            }
            else
            {
                ViewBag.message = "Error in registration.";
            }
            */
            vm.Pd = p.Pd;
            vm.Langs = new Language();
            return View(vm);
        }

        public ActionResult UpdateEdu(VM p)
        {
            vm.Langs = p.Langs;
            vm.Educ = new Education();

            return View(vm);
        }

        public ActionResult UpdateVH(VM p)
        {
            vm.Educ = p.Educ;
            vm.VolunteerNhobbies = new VolunteerHobby();

            return View(vm);
        }

        public ActionResult UpdateJobs(VM p)
        {
            vm.VolunteerNhobbies = p.VolunteerNhobbies;
            vm.Jobs = new PastJob();

            return View(vm);
        }

        public ActionResult UpdateDisa(VM p)
        {
            vm.Jobs = p.Jobs;
            vm.Disabilities = new Disability();

            return View(vm);
        }

        public ActionResult SetCV(VM p)
        {
            vm.Disabilities = p.Disabilities;


            DataLayer dal = new DataLayer();
            dal.personalDetails.Add(vm.Pd);
            dal.pastJobs.Add(vm.Jobs);
            dal.languages.Add(vm.Langs);
            dal.educations.Add(vm.Educ);
            dal.volunteerHobbies.Add(vm.VolunteerNhobbies);
            dal.disabilities.Add(vm.Disabilities);




            vm.Cv = new Models.CV()
            {
                id = vm.Pd.ID,
                Disabilities = vm.Disabilities.id,
                Langs = vm.Langs.id,
                Educ = vm.Educ.id,
                Jobs = vm.Jobs.id,
                VolunteerNhobbies = vm.VolunteerNhobbies.id
            };

            dal.cVs.Add(vm.Cv);
            dal.SaveChanges();


            if (vm.Employee != null)
            {
                vm.Employee.Cv = vm.Cv.id;
            }
            return View(vm);
        }


         
        public ActionResult BackMenu(VM p)
        {
            return RedirectToAction("EmployeeMenu", p.Employee);
        }

        public ActionResult ShowCV(VM c = null)
        {
// vm.Employee = c.Employee;
            DataLayer dal = new DataLayer();
            vm = new VM();

            List<CV> cv = (from x in dal.cVs
                                          where "1" == x.id  select x).ToList<CV>();
            if (cv.Count == 0)     //In case username was found
            {
                ViewBag.UserLoginMessage = "cv didnt found";
                return RedirectToAction("EmployeeMenu",c.Employee);
            }


            string id = cv[0].id.ToString();
            List<PersonalDetails> pd = (from x in dal.personalDetails
                           where x.ID == id
                           select x).ToList<PersonalDetails>();  
            vm.Pd = pd[0];


            int pid = cv[0].Langs;
            List<Language> lang = (from x in dal.languages
                                        where x.id == pid
                                        select x).ToList<Language>();
            vm.Langs = lang[0];


            pid = cv[0].Educ;
            List<Education> ed = (from x in dal.educations
                                        where x.id == pid
                                        select x).ToList<Education>();
            vm.Educ = ed[0];




            pid = cv[0].VolunteerNhobbies;
            List<VolunteerHobby> vol = (from x in dal.volunteerHobbies
                                        where x.id == pid
                                        select x).ToList<VolunteerHobby>();
            vm.VolunteerNhobbies = vol[0];




            pid = cv[0].Jobs;
            List<PastJob> job = (from x in dal.pastJobs
                                        where x.id == pid
                                        select x).ToList<PastJob>();
            vm.Jobs = job[0];




            pid = cv[0].Disabilities;
            List<Disability> dis = (from x in dal.disabilities
                                 where x.id == pid
                                 select x).ToList<Disability>();
            vm.Jobs = job[0];

            return View(vm);
        }

        public ActionResult LookingPublish(LookingAd lookAd)
        {
            if (ModelState.IsValid)
            {
                DataLayer dal = new DataLayer();
                dal.lookingAd.Add(lookAd);
                dal.SaveChanges();
                ViewBag.message = "Looking ad was published succesfully.";

                return View();
            }
            else
            {
                ViewBag.message = "Error in ad publishment.";
            }

            return View();
        }

        

    }
}