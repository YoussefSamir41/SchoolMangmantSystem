using Core.Bases;
using Core.Features.Department.Queries.Results;
using MediatR;

namespace Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentListCountQuery : IRequest<Response<List<GetDepartmentStudentListCountResults>>>
    {
    }
}
