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
    public class ManagerControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.Index() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void WatchTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.Watch() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void EditTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.Edit() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void ManagerRegisterTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.ManagerRegister() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void ManagerLoginTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.ManagerLogin() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void WantedBoardTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.WantedBoard() as ViewResult;
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void LookingBoardTest()
        {
            ManagerController con = new ManagerController();
            ViewResult res = con.LookingBoard() as ViewResult;
            Assert.IsNotNull(res);
        }

       
    }
}