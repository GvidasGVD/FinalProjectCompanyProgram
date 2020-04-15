using LoginProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LoginProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User userModel)
        {
            using (LoginDBEntities db = new LoginDBEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong user or password.";
                    return View("index", userModel);
                } else
                {
                    Session["userID"] = userDetails.Id;
                    Session["userName"] = userDetails.UserName;
                    return RedirectToAction("LoggedIn", "Home");

                }
            }
        }
        public ActionResult Logout()
        {
            //int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}