using Data.Entities.Views;
using Infrastructure.Abstracts;
using Infrastructure.Abstracts.Procedure;
using Infrastructure.Abstracts.Views;
using Infrastructure.InfrastructureBase;
using Infrastructure.Repository;
using Infrastructure.Repository.ProcedureRepository;
using Infrastructure.Repository.ViewRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));



            //views
            services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepository>();



            return services;
        }
    }
}
