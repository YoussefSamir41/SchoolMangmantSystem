using Core.Bases;
using Core.Features.Authorization.Queries.Results;
using MediatR;

namespace Core.Features.Authorization.Queries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesListResult>>>
    {
    }
}
