using AutoMapper;
using kaptast_formula1_api.Repository.Entities;
using kaptast_formula1_api.ViewModels.Models;

namespace kaptast_formula1_api.ViewModels.Profiles
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
