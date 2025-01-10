using Core.Features.Authorization.Commands.Models;
using Core.Features.Authorization.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BaseController;
using Swashbuckle.AspNetCore.Annotations;

namespace SchoolSystem.Controllers
{

    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.AuthorizationRouting.Edit)]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }


        [HttpDelete(Router.AuthorizationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await mediator.Send(new DeleteRoleCommand(id));
            return NewResult(response);
        }

        [HttpGet(Router.AuthorizationRouting.RoleList)]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await mediator.Send(new GetRolesListQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "idالصلاحية عن طريق ال", OperationId = "RoleById")]
        [HttpGet(Router.AuthorizationRouting.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var response = await mediator.Send(new GetRoleByIdQuery() { Id = id });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = " ادارة صلاحيات المستخدمين", OperationId = "ManageUserRoles")]
        [HttpGet(Router.AuthorizationRouting.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int userId)
        {
            var response = await mediator.Send(new ManageUserRolesQuery() { UserId = userId });
            return NewResult(response);
        }
    }
}
