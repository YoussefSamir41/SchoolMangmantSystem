using AutoMapper;
using Core.Bases;
using Core.Features.Department.Queries.Models;
using Core.Features.Department.Queries.Results;
using Data.Entities.Procedure;
using MediatR;
using Service.Abstracts;

namespace Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler :
        ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentListCountQuery, Response<List<GetDepartmentStudentListCountResults>>>,
        IRequestHandler<GetDepartmentStudentCountByIDQuery, Response<GetDepartmentStudentCountByIDResult>>


    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }


        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await departmentService.GetDepartmentById(request.Id);
            if (response == null)
            {
                return NotFound<GetDepartmentByIdResponse>("Not Found");

            }
            var mappeddepartment = mapper.Map<GetDepartmentByIdResponse>(response);
            return Success(mappeddepartment);
        }

        public async Task<Response<List<GetDepartmentStudentListCountResults>>> Handle(GetDepartmentStudentListCountQuery request, CancellationToken cancellationToken)
        {
            var viewDepartmentResult = await departmentService.GetViewDepartmentDataAsync();
            var result = mapper.Map<List<GetDepartmentStudentListCountResults>>(viewDepartmentResult);
            return Success(result);
        }

        public async Task<Response<GetDepartmentStudentCountByIDResult>> Handle(GetDepartmentStudentCountByIDQuery request, CancellationToken cancellationToken)
        {
            var parameters = mapper.Map<DepartmentStudentCountProcParameters>(request);
            var procResult = await departmentService.GetDepartmentStudentCountProcs(parameters);
            var result = mapper.Map<GetDepartmentStudentCountByIDResult>(procResult.FirstOrDefault());
            return Success(result);
        }
    }
}
