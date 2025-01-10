using AutoMapper;
using Core.Bases;
using Core.Features.Students.Queries.Models;
using Core.Features.Students.Queries.Results;
using Core.SharedResources;
using Core.Wrappers;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using Service.Abstracts;
using System.Linq.Expressions;

namespace Core.Features.Students.Queries.Handlers
{
    public class StudentHandler :

          ResponseHandler,
          IRequestHandler<GetStudentListQuery, Response<List<GetStudentListRespose>>>,
          IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
          IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResourc> stringLocalizer;


        public StudentHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResourc> stringLocalizer)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this.stringLocalizer = stringLocalizer;
        }
        public async Task<Response<List<GetStudentListRespose>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await studentService.GetStudentsAsync();
            var mappedStudents = mapper.Map<List<GetStudentListRespose>>(students);
            return Success(mappedStudents);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<GetSingleStudentResponse>(stringLocalizer[SharedResourcesKeys.NotFound]);
            var mappedStudent = mapper.Map<GetSingleStudentResponse>(student);
            return Success(mappedStudent);

        }



        Task<PaginatedResult<GetStudentPaginatedListResponse>> IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>.Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression =
            e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName);

            var querable = studentService.GetStudentQuerable();


            if (request.Serach != null)
            {
                querable = studentService.SearchByName(request.Serach);
            }
            if (request.OrderBy == "Address")
            {
                querable = studentService.OrderByName(x => x.Address);
            }

            var paginatedList = querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;

        }
    }
}
