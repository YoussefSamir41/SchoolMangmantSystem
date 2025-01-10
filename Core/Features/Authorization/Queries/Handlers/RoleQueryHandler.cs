using AutoMapper;
using Core.Bases;
using Core.Features.Authorization.Queries.Models;
using Core.Features.Authorization.Queries.Results;
using Data.Entities.Sec;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstracts;

namespace Core.Features.Authorization.Queries.Handlers
{
    public class RoleQueryHandler
        : ResponseHandler,
         IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>,
         IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
         IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>>
    {

        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        public RoleQueryHandler(
                                IAuthorizationService authorizationService,
                                IMapper mapper,
                                UserManager<User> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Success(result);
        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            if (role == null) return NotFound<GetRoleByIdResult>();
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Success(result);

        }

        public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserRolesResult>("User Not Found");
            var result = await _authorizationService.ManageUserRolesData(user);
            return Success((ManageUserRolesResult)result);
        }
    }
}
