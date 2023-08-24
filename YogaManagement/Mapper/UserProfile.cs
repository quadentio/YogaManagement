using AutoMapper;
using Data.Models;
using YogaManagement.ViewModel.Auth;

namespace YogaManagement.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // RegisterUserVM => User
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, options => options.MapFrom(src => src.Password));
        }
    }
}
