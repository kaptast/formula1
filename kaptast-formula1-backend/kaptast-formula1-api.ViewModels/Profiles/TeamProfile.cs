using AutoMapper;
using KaptastFormula1Api.Repository.Entities;
using KaptastFormula1Api.ViewModels.Models;

namespace KaptastFormula1Api.ViewModels.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>().ReverseMap();
        }
    }
}
