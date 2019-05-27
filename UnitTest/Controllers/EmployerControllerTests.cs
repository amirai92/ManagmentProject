using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication3.Controllers.Tests
{
    [TestClass()]
    public class EmployerControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            EmployerController con = new EmployerController();
            ViewResult res = con.Index() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void EmployerLoginTest()
        {
            EmployerController con = new EmployerController();
            ViewResult res = con.EmployerLogin() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void PublishOnWebTest()
        {
            EmployerController con = new EmployerController();
            ViewResult res = con.PublishOnWeb() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void WatchingContentTest()
        {
            EmployerController con = new EmployerController();
            ViewResult res = con.WatchingContent() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void WatchingTheBoardTest()
        {
            EmployerController con = new EmployerController();
            ViewResult res = con.WatchingTheBoard() as ViewResult;
            Assert.IsNotNull(res);
        }
    }
}