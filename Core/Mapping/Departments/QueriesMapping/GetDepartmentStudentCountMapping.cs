using Core.Features.Department.Queries.Results;
using Data.Entities.Views;

namespace Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentListCountResults>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount)); ;

        }
    }
}
