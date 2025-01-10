using Core.Features.Department.Queries.Models;
using Core.Features.Department.Queries.Results;
using Data.Entities.Procedure;

namespace Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountByIdMapping()
        {
            CreateMap<GetDepartmentStudentCountByIDQuery, DepartmentStudentCountProcParameters>();

            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountByIDResult>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Dname))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));


        }
    }
}
