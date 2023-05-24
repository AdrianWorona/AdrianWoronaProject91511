using AdrianWoronaProject91511.Migrations.IdentityApp;
using AdrianWoronaProject91511.Models;
using AdrianWoronaProject91511.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianWoronaProject91511.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager { get; }
        SignInManager<AppUser> signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if(ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,
                };

                var result = await userManager.CreateAsync(newUser, newUser.Password);
                var errorList = result.Errors.ToList();
                ViewBag.result = string.Join("\n", errorList.Select( e => e.Description));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }
            var result = await signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Nieudana próba logowania");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
