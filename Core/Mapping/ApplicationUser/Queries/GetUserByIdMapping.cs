using AutoMapper;
using Core.Features.ApplicationUser.Queries.Result;
using Data.Entities.Sec;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {

        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }




    }
}
