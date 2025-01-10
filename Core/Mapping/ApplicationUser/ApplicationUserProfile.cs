using AutoMapper;

namespace Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateUserMapping();
            GetUsersPaginatedMapping();
            GetUserByIdMapping();
            UpdatedUserMapping();
        }
    }
}
