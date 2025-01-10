using AutoMapper;

namespace Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
