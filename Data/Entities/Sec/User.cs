
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;


namespace Data.Entities.Sec
{

    public class User : IdentityUser<int>
    {

        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }

        [EncryptColumn]
        public string? Code { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }


}

