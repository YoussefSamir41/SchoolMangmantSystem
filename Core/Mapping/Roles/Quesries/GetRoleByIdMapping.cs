using Core.Features.Authorization.Queries.Results;
using Microsoft.AspNetCore.Identity;

namespace Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<IdentityRole<int>, GetRoleByIdResult>();
        }
    }
}
