using Core.Bases;
using Data.Helpers;
using MediatR;

namespace Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
