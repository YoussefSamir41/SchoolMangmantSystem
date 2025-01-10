using Core.Bases;
using Data.Helpers;
using MediatR;

namespace Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
