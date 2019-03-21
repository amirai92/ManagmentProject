using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Dal;



namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult DefaultLoad()
        {
            User defUser = new User
            {

                FirstName = "Amir",
                LastName = "Aizin",
                UserName = "Amir",
                Password = "123456"
            };
            return View("loggedin", defUser);
        }


        public ActionResult amir()
        {

            UserDal dal = new UserDal();
            List<User> objUsers = dal.Users.ToList<User>();
            return View();
        }
        public ActionResult enterSignUp ()
        {
            User obj = new User();
            return View("SignUp", obj);
        }
        public ActionResult SignUp(User usr)
        {
            //Make new controller that has sign up page and then send it to this action
            if (ModelState.IsValid)
            {

                UserDal dal = new UserDal();
                dal.Users.Add(usr);
                dal.SaveChanges();
                return View("loggedin", usr);

            }
            else
            {
                return View("amir", usr);
            }
        }
        public ActionResult UserLogin()
        {
            User user = new User();
            ViewBag.UserLoginMessage = "";
            return View(user);
        }

        public ActionResult Login(User user)
        {

            UserDal dal = new UserDal();
            //Encryption enc = new Encryption();
            List<User> userToCheck = (from x in dal.Users
                                      where (x.UserName == user.UserName) &&(x.Password == user.Password)
                                      select x).ToList<User>();       //Attempting to get user information from database
            if (userToCheck.Count != 0)     //In case username was found
            {
               
                return View("loggedin", userToCheck);
            }
            else
            {
                ViewBag.UserLoginMessage = "Incorrect Username/password";
                return View("UserLogin", userToCheck);
            }
        }


    }
}