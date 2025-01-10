using Core.Bases;
using MediatR;

namespace Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }

        public string Phone { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
    }
}
