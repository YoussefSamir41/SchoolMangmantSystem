using Core.Bases;
using Core.Features.Department.Queries.Results;
using MediatR;

namespace Core.Features.Department.Queries.Models
{
    public class GetDepartmentStudentCountByIDQuery : IRequest<Response<GetDepartmentStudentCountByIDResult>>
    {
        public int DID { get; set; }
    }
}
