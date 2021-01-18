using KaptastFormula1Api.ViewModels.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Interfaces
{
    public interface IAuthService
    {
        void Register(UserViewModel userModel);
        Task<SignInResult> Login(UserViewModel user);
        void LogOff();
    }
}
