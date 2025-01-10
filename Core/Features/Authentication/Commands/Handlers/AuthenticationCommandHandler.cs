using Core.Bases;
using Core.Features.Authentication.Commands.Models;
using Data.Entities.Sec;
using Data.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Abstracts;


namespace Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler :
        ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>,
         IRequestHandler<SendResetPasswordCommand, Response<string>>
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        private readonly IAuthenticationService authenticationService;

        public AuthenticationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authenticationService = authenticationService;
        }
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null) return BadRequest<JwtAuthResult>("UserName Not Found");
            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>("Passord is wrong");
            if (!user.EmailConfirmed)
                return BadRequest<JwtAuthResult>("Email Not Confirmed");
            var result = await authenticationService.GetJWTToken(user);
            return Success(result);

        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return BadRequest<JwtAuthResult>("AlgorithmIsWrong");
                case ("TokenIsNotExpired", null): return BadRequest<JwtAuthResult>("TokenIsNotExpired");
                case ("RefreshTokenIsNotFound", null): return BadRequest<JwtAuthResult>("RefreshTokenIsNotFound");
                case ("RefreshTokenIsExpired", null): return BadRequest<JwtAuthResult>("RefreshTokenIsExpired");
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await authenticationService.ResetPassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserNotFound");
                case "Failed": return BadRequest<string>("UserNotFound");
                case "Success": return Success<string>("Success");
                default: return BadRequest<string>("InvaildCode]");
            }
        }
    }
}

