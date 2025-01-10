using AutoMapper;

namespace Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
            GetDepartmentStudentCountMapping();
        }
    }
}
