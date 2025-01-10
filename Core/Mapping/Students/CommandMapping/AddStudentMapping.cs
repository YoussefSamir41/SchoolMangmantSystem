using Core.Features.Students.Commands.Models;
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
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>()
           .ForMember(dest => dest.DID, option => option.MapFrom(src => src.DepartmentId));


        }
    }
}
