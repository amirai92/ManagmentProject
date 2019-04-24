using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Dal;
using System.Web.Security;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
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
        public ActionResult WatchingTheBoard()
        {
            return View();
        }
        /*This function handles signing out*/
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult enterSignUp ()
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
            List<Manager> users = dal.managers.ToList<Manager>();
            foreach (Manager manager in dal.managers)
                if (manager.UserName.Equals(userName))
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
                                      where (x.UserName == emp.UserName) &&(x.Password == emp.Password)
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
          
            return View(new LookingAd("sali", "sali@ac.com", "0506502199", true, true, false, false,null));
        }
        
        public ActionResult CreateCV(Employee emp)
        {
            VM vm = new VM();
            vm.Employee = emp;
            vm.Pd = new PersonalDetails();

            return View(vm);
        }
        
       

    }
}