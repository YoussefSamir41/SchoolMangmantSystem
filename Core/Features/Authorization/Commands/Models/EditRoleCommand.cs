using Core.Bases;
using Data.Requests;
using MediatR;

namespace Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
