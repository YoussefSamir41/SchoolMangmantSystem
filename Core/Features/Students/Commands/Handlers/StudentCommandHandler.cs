using AutoMapper;
using Core.Bases;
using Core.Features.Students.Commands.Models;
using Data.Entities;
using MediatR;
using Service.Abstracts;

namespace Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler :
        ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>


    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedStudent = mapper.Map<Student>(request);
            var res = await studentService.AddAsync(mappedStudent);
            return Success("Student Added Successfuly");
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");
            var mappedstudent = mapper.Map<Student>(request);
            var res = await studentService.EditAsync(mappedstudent);
            if (res == "Success") return Success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");
            var res = await studentService.RemoveAsync(student);
            if (res == "Success") return Success("Deleted Successfully");
            else return BadRequest<string>();

        }
    }
}
