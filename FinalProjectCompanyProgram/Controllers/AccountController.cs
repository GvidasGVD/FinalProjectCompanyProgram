using AutoMapper;
using FinalProjectCompanyProgram.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalProjectCompanyProgram.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        //The UserManager class comes from the Microsoft.AspNetCore.Identity namespace and 
        //it provides a set of helper methods to help manage a user in the application.
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = _mapper.Map<User>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                
                return View(userModel);
            }

            await _userManager.AddToRoleAsync(user, "Visitor");
            var newUser = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, false, false);
            return RedirectToLocal(returnUrl);
            //return RedirectToAction(nameof(DoorsController.Index), "Doors");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.UserName, userModel.Password, userModel.RememberMe, false);
            var user = await _userManager.FindByNameAsync(userModel.UserName);
            if(user == null)
            {
                // return View(userModel);
                ModelState.AddModelError("", "Invalid User Name or Password");
                return View();
            } else
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (result.Succeeded)
                {
                    if (roles.Contains("Administrator"))
                    {
                        //return RedirectToAction("Index", "Administrator");
                        return RedirectToLocal(returnUrl);
                    }

                    if (roles.Contains("Visitor"))
                    {
                        //return RedirectToAction("Index", "Visitor");
                        return RedirectToLocal(returnUrl);
                    }

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}