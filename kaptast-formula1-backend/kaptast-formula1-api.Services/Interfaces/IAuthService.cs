using kaptast_formula1_api.ViewModels.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Services.Interfaces
{
    public interface IAuthService
    {
        void Register(UserViewModel userModel);
        Task<SignInResult> Login(UserViewModel user);
        void LogOff();
    }
}
