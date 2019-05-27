using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {

        [TestMethod()]
        public void WatchingContentTest()
        {
            EmployeeController con = new EmployeeController();
            ViewResult res = con.WatchingContent() as ViewResult;
            Assert.IsNotNull(res);

        }

        [TestMethod()]
        public void EmployeeLoginTest()
        {
            EmployeeController con = new EmployeeController();
            ViewResult res = con.EmployeeLogin() as ViewResult;
            Assert.IsNotNull(res);
        }
    }
}