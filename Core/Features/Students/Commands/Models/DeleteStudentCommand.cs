using MediatR;

namespace Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Bases.Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
