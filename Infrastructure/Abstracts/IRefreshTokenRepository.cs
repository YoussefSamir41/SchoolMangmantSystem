using Data.Entities.Sec;
using Infrastructure.InfrastructureBase;

namespace Infrastructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
