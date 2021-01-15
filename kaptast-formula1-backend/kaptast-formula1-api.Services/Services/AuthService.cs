using kaptast_formula1_api.Services.Interfaces;
using kaptast_formula1_api.ViewModels.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public async Task<SignInResult> Login(UserViewModel user)
        {
            return await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, lockoutOnFailure: false);
        }

        public async void LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
