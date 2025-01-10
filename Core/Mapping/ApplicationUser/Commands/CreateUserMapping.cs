using AutoMapper;
using Core.Features.ApplicationUser.Commands.Models;
using Data.Entities.Sec;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public void CreateUserMapping()
        {
            CreateMap<AddUserCommand, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

        }
    }
}
