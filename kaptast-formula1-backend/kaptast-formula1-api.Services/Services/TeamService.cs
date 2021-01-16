using AutoMapper;
using kaptast_formula1_api.Repository.Entities;
using kaptast_formula1_api.Repository.Repositories.Interfaces;
using kaptast_formula1_api.Services.Interfaces;
using kaptast_formula1_api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Services.Services
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

        public async void Add(TeamViewModel team)
        {
            Team teamEntity = _mapper.Map<Team>(team);

            this._repository.Add(teamEntity);
            await this._repository.Save();
        }

        public async void Delete(TeamViewModel team)
        {
            Team teamEntity = _mapper.Map<Team>(team);

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

        public async void Update(TeamViewModel team)
        {
            Team teamEntity = _mapper.Map<Team>(team);

            this._repository.Update(teamEntity);
            await this._repository.Save();
        }
    }
}
