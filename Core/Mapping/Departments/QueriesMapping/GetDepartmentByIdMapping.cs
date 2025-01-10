using AutoMapper;
using Core.Features.Department.Queries.Results;
using Data.Entities;

namespace Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors))
                ;

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.SubjectName));


            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
