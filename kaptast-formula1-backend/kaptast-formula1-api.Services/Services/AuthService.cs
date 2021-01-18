﻿using KaptastFormula1Api.Services.Interfaces;
using KaptastFormula1Api.ViewModels.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public async void Register(UserViewModel userModel)
        {
            var user = new IdentityUser() { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
        }

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
