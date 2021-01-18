using KaptastFormula1Api.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KaptastFormula1Api.Services.Interfaces
{
    public interface ITeamService
    {
        Task Add(TeamViewModel team);
        Task<TeamViewModel> Get(Guid Id);
        Task<IEnumerable<TeamViewModel>> Get();
        Task Update(TeamViewModel team);
        Task Delete(Guid id);
    }
}
