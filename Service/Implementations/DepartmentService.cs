using Data.Entities;
using Data.Entities.Procedure;
using Data.Entities.Views;
using Infrastructure.Abstracts;
using Infrastructure.Abstracts.Procedure;
using Infrastructure.Abstracts.Views;
using Microsoft.EntityFrameworkCore;
using Service.Abstracts;

namespace Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IViewRepository<ViewDepartment> _viewDepartmentRepository;
        private readonly IDepartmentStudentCountProcRepository departmentStudentCountProcRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IViewRepository<ViewDepartment> viewDepartmentRepository, IDepartmentStudentCountProcRepository departmentStudentCountProcRepository)
        {
            this.departmentRepository = departmentRepository;
            _viewDepartmentRepository = viewDepartmentRepository;
            this.departmentStudentCountProcRepository = departmentStudentCountProcRepository;
        }
        public Task<Department> GetDepartmentById(int id)
        {
            var departments = departmentRepository


                   .GetTableNoTracking()
                   .Where(x => x.DID.Equals(id))
                   .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                   .Include(x => x.Students)
                   .Include(x => x.Instructors)
                   .FirstOrDefaultAsync();


            return departments;
        }

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters)
        {
            return await departmentStudentCountProcRepository.GetDepartmentStudentCountProcs(parameters);
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentDataAsync()
        {
            var departments = await _viewDepartmentRepository.GetTableNoTracking()
                .ToListAsync();

            // Assuming ViewDepartment has similar properties to Department,
            // map them explicitly.
            var viewDepartments = departments.Select(d => new ViewDepartment
            {
                DID = d.DID, // or any relevant properties
                DName = d.DName // map other properties as needed
            }).ToList();

            return viewDepartments;
        }

        public async Task<bool> IsDepartmentIdExist(int departmentId)
        {
            return await departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(departmentId));
        }
    }
}
