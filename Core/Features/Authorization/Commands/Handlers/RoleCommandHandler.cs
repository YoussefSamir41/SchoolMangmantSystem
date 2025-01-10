using Core.Bases;
using Core.Features.Authorization.Commands.Models;
using MediatR;
using Service.Abstracts;

namespace Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler :
         ResponseHandler,
         IRequestHandler<AddRoleCommand, Response<string>>,
         IRequestHandler<EditRoleCommand, Response<string>>,
         IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService authorizationService;

        public RoleCommandHandler(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Success") return Success("");
            return BadRequest<string>("Add Role Failed");
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.EditRoleAsync(request);
            if (result == "notFound") return NotFound<string>("Not Found");
            else if (result == "Success") return Success("Updated Successfully");
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationService.DeleteRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Used") return BadRequest<string>("Used");
            else if (result == "Success") return Success("Deleted Succssfully");
            else
                return BadRequest<string>(result);
        }
    }
}
