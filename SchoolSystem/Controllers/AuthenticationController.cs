using Core.Features.Authentication.Commands.Models;
using Core.Features.Authentication.Queries.Models;
using Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BaseController;

namespace SchoolSystem.Controllers
{

    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> Create([FromQuery] SignInCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery query)
        {
            var response = await mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet(Router.Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await mediator.Send(query);
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.SendResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] SendResetPasswordCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
    }
}
