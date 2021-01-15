using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kaptast_formula1_api.Services.Interfaces;
using kaptast_formula1_api.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace kaptast_formula1_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService auth)
        {
            this._authService = auth;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _authService.Register(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(model);
                if (result.Succeeded)
                {
                    return LocalRedirect("/");
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult LogOff()
        {
            _authService.LogOff();
            return Ok();
        }

    }
}
