using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Dal;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: User
        public ActionResult DefaultLoad()
        {
            Employee defUser = new Employee("Amir", "123456", "Amir", "Aizin");
            return View("loggedin", defUser);
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

                DataLayer dal = new DataLayer();
                dal.employees.Add(emp);
                dal.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View("EmployeeSignUp", emp);
            }
        }
        public ActionResult UserLogin()
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
               
                return View("loggedin", emp);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("UserLogin", emp);
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



    }
}