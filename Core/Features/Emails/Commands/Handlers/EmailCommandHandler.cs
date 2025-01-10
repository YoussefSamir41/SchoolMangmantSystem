using Core.Bases;
using Core.Features.Emails.Commands.Models;
using MediatR;
using Service.Abstracts;

namespace Core.Features.Emails.Commands.Handlers
{
    public class EmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IEmailsService _emailsService;

        #endregion
        #region Constructors
        public EmailCommandHandler(
                                    IEmailsService emailsService)
        {
            _emailsService = emailsService;

        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Message, null);
            if (response == "Success")
                return Success<string>("");
            return BadRequest<string>("Send Email Failed");
        }
        #endregion
    }
}
