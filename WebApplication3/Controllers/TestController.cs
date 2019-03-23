using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AutoLoad()
        {
            Employee emp = new Employee {
                FirstName="Test",
                LastName="Test",
                UserName="TestName",
                Password="123"
            };
            return View(emp);

        }
        public ActionResult CheckLogIn(Employee emp)
        {
            if (ModelState.IsValid)
            {
                DataLayer dal = new DataLayer();
                dal.employees.Add(emp);
                dal.SaveChanges();
                Console.WriteLine("Succesful logged in and saved in DB\n");
                return View("loggedin", emp);
            }
            else
            {
                Console.WriteLine("Couldnt add the user,try agian\n");
                return View("AutoLoad");
            }
        }
    }
}