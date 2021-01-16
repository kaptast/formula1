using AutoMapper;
using kaptast_formula1_api.Repository.Entities;
using kaptast_formula1_api.ViewModels.Models;

namespace kaptast_formula1_api.ViewModels.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamViewModel>().ReverseMap();
        }
    }
}
