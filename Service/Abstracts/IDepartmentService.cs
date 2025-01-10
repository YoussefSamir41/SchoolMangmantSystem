using Data.Entities;
using Data.Entities.Procedure;
using Data.Entities.Views;

namespace Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
        Task<List<ViewDepartment>> GetViewDepartmentDataAsync();

        public Task<bool> IsDepartmentIdExist(int departmentId);

        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameters parameters);
    }
}
