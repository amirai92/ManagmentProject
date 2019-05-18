using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeSignUp()
        {
            Employee emp = new Employee("vfjdbhlu", "123456", "Adir", "Sabag");

            EmployeeController controller = new EmployeeController();

            ActionResult result = controller.EmployeeSignUp(emp);
            
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
