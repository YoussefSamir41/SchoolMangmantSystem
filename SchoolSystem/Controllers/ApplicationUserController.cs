using Core.Features.ApplicationUser.Commands.Models;
using Core.Features.ApplicationUser.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BaseController;

namespace SchoolSystem.Controllers
{

    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }


        [HttpGet(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }


        [HttpPut(Router.UserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }


        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            return NewResult(await mediator.Send(new DeleteUserCommand(id)));
        }


        [HttpPut(Router.UserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
    }
}
