using AutoMapper;
using Core.Features.Students.Commands.Models;
using Data.Entities;

namespace Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>()
           .ForMember(dest => dest.DID, option => option.MapFrom(src => src.DepartmentId))
           .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id));


        }
    }
}
