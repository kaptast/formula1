using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaptastFormula1Api.Services.Interfaces;
using KaptastFormula1Api.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KaptastFormula1Api.Controllers
{
    /// <summary>
    /// Contoller for handling Authorization routes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService auth, IConfiguration configuration)
        {
            this._authService = auth;
            this._configuration = configuration;
        }

        /// <summary>
        /// Route only available if the user is authenticated.
        /// </summary>
        /// <returns><see cref="IActionResult"/> with HTTP Status code 200.</returns>
        // GET /api/auth
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Route used to login the user.
        /// </summary>
        /// <param name="model">User model containing the user's username and password.</param>
        /// <returns>An <see cref="IActionResult"/> with HTTP status code 401, or if the login was successful HTTP Status code 200 and a JSON object containing the Bearer token and expiry date.</returns>
        // POST /api/auth/login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            // Try to login with the supplied credentials
            var result = await _authService.Login(model);
            if (result.Succeeded)
            {
                // If the login was successful generate a token for the user
                var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Token"]));
                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                // And return the token with the successful response.
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        /// <summary>
        /// Route used to logout the user.
        /// </summary>
        /// <returns><see cref="IActionResult"/> with HTTP Status code 200 if the logout was successful.</returns>
        // POST /api/auth/logout
        [HttpPost]
        [Authorize]
        [Route("logout")]
        public IActionResult LogOff()
        {
            _authService.LogOff();
            return Ok();
        }

    }
}
