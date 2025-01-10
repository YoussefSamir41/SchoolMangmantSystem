using AutoMapper;
using Core.Bases;
using Core.Features.ApplicationUser.Queries.Models;
using Core.Features.ApplicationUser.Queries.Result;
using Core.Wrappers;
using Data.Entities.Sec;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Features.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler :

        ResponseHandler,
        IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationResponse>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>

    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<PaginatedResult<GetUserPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = userManager.Users.AsQueryable();

            var paginatedList = await mapper.ProjectTo<GetUserPaginationResponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(u => u.Id == request.Id);
            if (user == null) return NotFound<GetUserByIdResponse>("User does not Exist");
            var mappeduser = mapper.Map<GetUserByIdResponse>(user);
            return Success(mappeduser);
        }
    }
}
