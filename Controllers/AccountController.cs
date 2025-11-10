using FirstProjectApp.Data.Entities;
using FirstProjectApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Redirect based on role
                var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                if (roles.Contains("SuperAdmin")) return RedirectToAction("Index", "SuperAdmin");
                if (roles.Contains("Admin")) return RedirectToAction("Index", "Admin");
                if (roles.Contains("Teacher")) return RedirectToAction("Index", "Teacher");
                if (roles.Contains("Student")) return RedirectToAction("Index", "Student");

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

            public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
