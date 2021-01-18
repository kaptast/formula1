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
    /// <summary>
    /// A controller for Team CRUD methods.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            this._teamService = teamService;
        }

        /// <summary>
        /// Gets all the teams in the database.
        /// </summary>
        /// <returns>A list with all the teams.</returns>
        // GET /api/team
        [HttpGet]
        public async Task<IEnumerable<TeamViewModel>> Get()
        {
            return await this._teamService.Get();
        }

        /// <summary>
        /// Gets the team identified by the Id.
        /// </summary>
        /// <param name="id">Id of the queried team.</param>
        /// <returns>A team object with the specified Id.</returns>
        // GET /api/team/{id}
        [HttpGet("{id}")] 
        public async Task<TeamViewModel> Get(Guid id)
        {
            return await this._teamService.Get(id);
        }

        /// <summary>
        /// Adds team to the database.
        /// </summary>
        /// <param name="teamViewModel">Team model to be added to the database.</param>
        /// <returns>An <see cref="IActionResult"/> with HTTP Status code 200 if the add was successful.</returns>
        // POST /api/team
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TeamViewModel teamViewModel)
        {
            await this._teamService.Add(teamViewModel);

            return Ok();
        }

        /// <summary>
        /// Updates the team in the database.
        /// </summary>
        /// <param name="teamViewModel">Model of the team which needs to be updated.</param>
        /// <returns>An <see cref="IActionResult"/> with HTTP Status code 200 if the update was successful.</returns>
        // PUT /api/team
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(TeamViewModel teamViewModel)
        {
            await this._teamService.Update(teamViewModel);

            return Ok();
        }

        /// <summary>
        /// Deletes teh team from the database.
        /// </summary>
        /// <param name="id">Id of the team which will be deleted.</param>
        /// <returns>An <see cref="IActionResult"/> with HTTP Status code 200 if the delete was successful.</returns>
        // DELETE /api/team/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._teamService.Delete(id);

            return Ok();
        }
    }
}
