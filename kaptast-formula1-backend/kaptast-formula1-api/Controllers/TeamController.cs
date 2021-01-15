﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kaptast_formula1_api.Services.Interfaces;
using kaptast_formula1_api.ViewModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kaptast_formula1_api.Controllers
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
    }
}