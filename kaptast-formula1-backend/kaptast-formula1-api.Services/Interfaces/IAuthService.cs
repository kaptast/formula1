using KaptastFormula1Api.ViewModels.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Interfaces
{
    /// <summary>
    /// A service for user authentication.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers the user with the UserManager.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns>An awaitable task which registers the user.</returns>
        Task<IdentityResult> Register(UserViewModel userModel);

        /// <summary>
        /// Logins with the credentials supplied in the parameter.
        /// </summary>
        /// <param name="user">An user object with username and password.</param>
        /// <returns>An awaitable task which tries to login the user and return the sign in result.</returns>
        Task<SignInResult> Login(UserViewModel user);

        /// <summary>
        /// Logs off the current user.
        /// </summary>
        /// <returns>An awaitable task which logs off the user.</returns>
        Task LogOff();
    }
}
