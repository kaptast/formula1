using AutoMapper;
using KaptastFormula1Api.Repository.Entities;
using KaptastFormula1Api.ViewModels.Models;

namespace KaptastFormula1Api.ViewModels.Profiles
{
    /// <summary>
    /// A mapping profile between <see cref="Team"/> and <see cref="TeamViewModel"/>
    /// </summary>
    public class TeamProfile : Profile
    {
        /// <summary>
        /// Creates the profile between <see cref="Team"/> and <see cref="TeamViewModel"/>
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>().ReverseMap();
        }
    }
}
