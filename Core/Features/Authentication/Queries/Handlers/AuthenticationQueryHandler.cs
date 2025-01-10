using Core.Bases;
using Core.Features.Authentication.Queries.Models;
using MediatR;
namespace Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<AuthorizeUserQuery, Response<string>>,
        IRequestHandler<ConfirmEmailQuery, Response<string>>


    {
        private readonly Service.Abstracts.IAuthenticationService authenticationService;

        public AuthenticationQueryHandler(Service.Abstracts.IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return BadRequest<string>("Token is Expired");
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await authenticationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("ErrorWhenConfirmEmail");
            return Success<string>("ConfirmEmailDone");
        }
    }
}
