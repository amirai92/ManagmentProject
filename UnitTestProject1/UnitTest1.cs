using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using WebApplication3.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeSignUp()
        {
            EmployeeController controller = new EmployeeController();

            ViewResult result = controller.EmployeeSignUp() as ViewResult;

        }
    }
}
