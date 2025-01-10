using Core.Features.ApplicationUser.Commands.Models;
using FluentValidation;

namespace Core.Features.ApplicationUser.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {


        public AddUserValidator()
        {

            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name Can not be Null")
                .MaximumLength(200).WithMessage("Max Length Must be Less Than 20 Char");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Address can not be empty")
                .NotNull().WithMessage("Address Can not be Null")
                .MaximumLength(200).WithMessage("Max Length Must be Less Than 20 Char");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password can not be empty")
               .NotNull().WithMessage("Password Can not be Null")
               .MaximumLength(200).WithMessage("Max Length Must be Less Than 20 Char");


            RuleFor(x => x.ConfirmedPassword)
               .NotEmpty().WithMessage("ConfirmedPassword can not be empty")
               .NotNull().WithMessage("ConfirmedPassword Can not be Null")
               .MaximumLength(20).WithMessage("Max Length Must be Less Than 20 Char");


        }
    }
}
