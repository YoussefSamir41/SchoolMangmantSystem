using Data.Entities.Views;
using Infrastructure.Abstracts.Views;
using Infrastructure.Context;
using Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ViewRepository
{
    public class ViewDepartmentRepository : GenericRepositoryAsync<ViewDepartment>, IViewRepository<ViewDepartment>
    {
        #region Fields
        private DbSet<ViewDepartment> viewDepartment;
        #endregion

        #region Constructors
        public ViewDepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            viewDepartment = dbContext.Set<ViewDepartment>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
