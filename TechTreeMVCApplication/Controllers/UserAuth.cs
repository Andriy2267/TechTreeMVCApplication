using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTreeMVCApplication.Data;
using TechTreeMVCApplication.Entities;
using TechTreeMVCApplication.Models;

namespace TechTreeMVCApplication.Controllers
{
    public class UserAuth : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserAuth(ApplicationDbContext context,
                        SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";

            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                                                                      loginModel.Password,
                                                                      loginModel.RememberMe,
                                                                      lockoutOnFailure: false);
                if (result.Succeeded)
                    loginModel.LoginInValid = "";
                else
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return PartialView("_UserLoginPartial", loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
                return LocalRedirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
