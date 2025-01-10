using Core.Features.Students.Queries.Results;
using Core.Wrappers;
using MediatR;

namespace Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? OrderBy { get; set; }
        public string? Serach { get; set; }
    }
}
