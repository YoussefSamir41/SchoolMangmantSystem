using AutoMapper;
using Core.Features.Authorization.Queries.Results;
using Microsoft.AspNetCore.Identity;

namespace Core.Mapping.Roles
{
    public partial class RoleProfile : Profile
    {
        public void GetRolesListMapping()
        {
            CreateMap<IdentityRole<int>, GetRolesListResult>();
        }
    }
}
