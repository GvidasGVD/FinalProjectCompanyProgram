using FinalProjectCompanyProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace FinalProjectCompanyProgram.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginDBContext _db;

        //[BindProperty]
        //public User User { get; set; }
        public LoginController(LoginDBContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorize(User userModel)
        {
            var user = await _db.Users.FirstOrDefaultAsync(m => m.UserName == userModel.UserName);
            if (user == null)
            {
                userModel.LoginErrorMessage = "No User found";
                return RedirectToAction("Index", "Login");
            }
            else if (userModel.UserName == user.UserName && userModel.Password == user.Password)
            {
               // Session["userID"] = user.Id;
               // Session["userName"] = user.UserName;
                return RedirectToAction("Index", "Home");
            }else
            {
                userModel.LoginErrorMessage = "Wrong user name or password";
                return RedirectToAction("Index", userModel);
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