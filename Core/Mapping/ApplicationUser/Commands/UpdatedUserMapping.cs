using AutoMapper;
using Core.Features.ApplicationUser.Commands.Models;
using Data.Entities.Sec;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public void UpdatedUserMapping()
        {
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
