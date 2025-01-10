using Core.Features.Department.Queries.Results;
using MediatR;

namespace Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Bases.Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }



        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
