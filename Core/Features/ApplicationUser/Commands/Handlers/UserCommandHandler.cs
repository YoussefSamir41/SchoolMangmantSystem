using AutoMapper;
using Core.Bases;
using Core.Features.ApplicationUser.Commands.Models;
using Data.Entities.Sec;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Abstracts;

namespace Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler :
        ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>







    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IApplicationUserService applicationUserService;

        public UserCommandHandler(IMapper mapper, UserManager<User> userManager, IApplicationUserService applicationUserService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.applicationUserService = applicationUserService;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = mapper.Map<User>(request);
            //Create
            var createResult = await applicationUserService.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>("EmailIsExist");
                case "UserNameIsExist": return BadRequest<string>("UserNameIsExist");
                case "ErrorInCreateUser": return BadRequest<string>("ErrorInCreateUser");
                case "Failed": return BadRequest<string>("Failed");
                case "Success": return Success<string>("Success");
                default: return BadRequest<string>(createResult);
            }

        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var olduser = await userManager.FindByEmailAsync(request.Email);
            if (olduser == null) return NotFound<string>("User Is Not Exist");
            var newuser = mapper.Map(request, olduser);
            var res = await userManager.UpdateAsync(newuser);
            if (!res.Succeeded) return BadRequest<string>("User Does not Updated");
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<string>("User Is Not Exist");
            var res = await userManager.DeleteAsync(user);
            if (!res.Succeeded) return BadRequest<string>("User Does not Deleted");
            return Success("");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<string>();
            var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success(" Password Change Succssefully ");
        }
    }
}
