using Data.Entities.Sec;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        private DbSet<UserRefreshToken> userRefreshToken;

        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            userRefreshToken = dbContext.Set<UserRefreshToken>();
        }
    }
}
