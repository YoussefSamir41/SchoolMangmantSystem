using Core.Features.Authentication.Commands.Models;
using FluentValidation;

namespace Core.Features.Authentication.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        public SignInValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name Can not be Null")
                .MaximumLength(200).WithMessage("Max Length Must be Less Than 20 Char");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Address can not be empty")
                .NotNull().WithMessage("Address Can not be Null")
                .MaximumLength(200).WithMessage("Max Length Must be Less Than 20 Char");

        }
    }
}
