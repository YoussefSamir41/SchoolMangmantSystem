using Core.Features.ApplicationUser.Queries.Result;
using Core.Wrappers;
using MediatR;

namespace Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        //public GetUserPaginationQuery(int? pageNumber, int? pageSize)
        //{
        //    PageNumber = pageNumber;
        //    PageSize = pageSize;
        //}
    }
}
