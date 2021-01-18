using AutoMapper;
using KaptastFormula1Api.Repository.Entities;
using KaptastFormula1Api.Repository.Repositories.Interfaces;
using KaptastFormula1Api.Services.Interfaces;
using KaptastFormula1Api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task Add(TeamViewModel team)
        {
            Team teamEntity = _mapper.Map<Team>(team);

            this._repository.Add(teamEntity);
            await this._repository.Save();
        }

        public async Task Delete(Guid id)
        {
            var teamEntity = await this._repository.Get(id);

            this._repository.Delete(teamEntity);
            await this._repository.Save();
        }

        public async Task<TeamViewModel> Get(Guid Id)
        {
            var team = await _repository.Get(Id);

            return _mapper.Map<TeamViewModel>(team);
        }

        public async Task<IEnumerable<TeamViewModel>> Get()
        {
            var teams = await _repository.Get();

            return _mapper.Map<List<Team>, IEnumerable<TeamViewModel>>(teams);
        }

        public async Task Update(TeamViewModel team)
        {
            Team teamEntity = _mapper.Map<Team>(team);

            this._repository.Update(teamEntity);
            await this._repository.Save();
        }
    }
}
