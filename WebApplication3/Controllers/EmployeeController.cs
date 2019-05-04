using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Dal;
using System.Web.Security;
using WebApplication3.ViewModel;

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
                    DataLayer dal = new DataLayer();
                    dal.employees.Add(emp);
                    dal.SaveChanges();
                    ViewBag.message = "Employee was added succesfully.";
                    return View("EmployeeMenu", emp);
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
            List<Employee> userToCheck = (from x in dal.employees
                                          where (x.UserName == emp.UserName) && (x.Password == emp.Password)
                                          select x).ToList<Employee>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {
                return View("EmployeeMenu", emp);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("EmployeeLogin", emp);
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
            dal.personalDetails.Add(p.Pd);
            dal.pastJobs.Add(p.Jobs);
            dal.languages.Add(p.Langs);
            dal.educations.Add(p.Educ);
            dal.volunteerHobbies.Add(p.VolunteerNhobbies);
            dal.disabilities.Add(p.Disabilities);

            dal.SaveChanges();
            ViewBag.message = "Employee was added succesfully.";



            vm.Cv = new Models.CV()
            {
                id = vm.Pd.ID,
                Disabilities = vm.Disabilities.id,
                Langs = vm.Langs.id,
                Educ = vm.Educ.id,
                Jobs = vm.Jobs.id,
                VolunteerNhobbies = vm.VolunteerNhobbies.id
            };

            if (vm.Employee != null)
            {
                vm.Employee.Cv = vm.Cv.cvId;
            }
            return View(vm);
        }



        public ActionResult BackMenu(VM p)
        {
            return RedirectToAction("EmployeeMenu", p.Employee);
        }

        public ActionResult ShowCV(VM c)
        {
            vm.Employee = c.Employee;
            DataLayer dal = new DataLayer();

            List<CV> cv = (from x in dal.cVs
                                          where c.Employee.Cv == x.cvId  select x).ToList<CV>();
            if (cv.Count == 0)     //In case username was found
            {
                ViewBag.UserLoginMessage = "cv didnt found";
                return RedirectToAction("EmployeeMenu",c.Employee);
            }



            List<PersonalDetails> pd = (from x in dal.personalDetails
                           where x.ID == cv[0].id
                           select x).ToList<PersonalDetails>();  
            vm.Pd = pd[0];



            List<Language> lang = (from x in dal.languages
                                        where x.id == cv[0].Langs
                                        select x).ToList<Language>();
            vm.Langs = lang[0];



            List<Education> ed = (from x in dal.educations
                                        where x.id == cv[0].Educ
                                        select x).ToList<Education>();
            vm.Educ = ed[0];





            List<VolunteerHobby> vol = (from x in dal.volunteerHobbies
                                        where x.id == cv[0].VolunteerNhobbies
                                        select x).ToList<VolunteerHobby>();
            vm.VolunteerNhobbies = vol[0];




            List<PastJob> job = (from x in dal.pastJobs
                                        where x.id == cv[0].Jobs
                                        select x).ToList<PastJob>();
            vm.Jobs = job[0];





            List<Disability> dis = (from x in dal.disabilities
                                 where x.id == cv[0].Disabilities
                                 select x).ToList<Disability>();
            vm.Jobs = job[0];





            return View(c);
        }

    }
}