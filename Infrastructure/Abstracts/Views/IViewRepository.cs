using Infrastructure.InfrastructureBase;

namespace Infrastructure.Abstracts.Views
{
    public interface IViewRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}
