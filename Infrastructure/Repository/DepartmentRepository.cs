using Data.Entities;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private DbSet<Department> departments;

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            departments = dbContext.Set<Department>();
        }
    }
}
