using Core.Features.Students.Queries.Results;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListRespose>()
           .ForMember(dest => dest.DepartmentName, option => option.MapFrom(src => src.Department.DName));

           
        }
    }
}
