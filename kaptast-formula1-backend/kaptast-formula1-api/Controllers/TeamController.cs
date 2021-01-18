using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaptastFormula1Api.Services.Interfaces;
using KaptastFormula1Api.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaptastFormula1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            this._teamService = teamService;
        }

        [HttpGet] // GET /api/team
        public async Task<IEnumerable<TeamViewModel>> Get()
        {
            return await this._teamService.Get();
        }

        [HttpGet("{id}")] // GET /api/team/xyz
        public async Task<TeamViewModel> Get(Guid id)
        {
            return await this._teamService.Get(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TeamViewModel teamViewModel)
        {
            await this._teamService.Add(teamViewModel);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(TeamViewModel teamViewModel)
        {
            await this._teamService.Update(teamViewModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._teamService.Delete(id);

            return Ok();
        }
    }
}
