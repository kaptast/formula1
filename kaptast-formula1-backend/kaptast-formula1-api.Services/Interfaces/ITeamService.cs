using kaptast_formula1_api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kaptast_formula1_api.Services.Interfaces
{
    public interface ITeamService
    {
        void Add(TeamViewModel team);
        Task<TeamViewModel> Get(Guid Id);
        Task<IEnumerable<TeamViewModel>> Get();
        void Update(TeamViewModel team);
        void Delete(TeamViewModel team);
    }
}
