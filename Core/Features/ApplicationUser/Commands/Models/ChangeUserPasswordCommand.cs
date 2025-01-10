using Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Features.ApplicationUser.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
