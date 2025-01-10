
namespace Core.Features.Authorization.Queries.Results
{
    public class ManageUserRolesResult
    {
        public int UserId { get; set; }
        public List<UserRoles> userRoles { get; set; }

        public static explicit operator ManageUserRolesResult(Service.Abstracts.ManageUserRolesResultTemp v)
        {
            throw new NotImplementedException();
        }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }

    }
}
