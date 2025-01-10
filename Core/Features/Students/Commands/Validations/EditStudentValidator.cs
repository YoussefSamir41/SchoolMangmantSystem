using Core.Features.Students.Commands.Models;
using FluentValidation;

namespace Core.Features.Students.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        public EditStudentValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name Can not be Null")
                .MaximumLength(20).WithMessage("Max Length Must be Less Than 20 Char");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address can not be empty")
                .NotNull().WithMessage("Address Can not be Null")
                .MaximumLength(20).WithMessage("Max Length Must be Less Than 20 Char");

        }
    }
}
