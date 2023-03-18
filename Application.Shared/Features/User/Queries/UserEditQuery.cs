using Application.Shared.Features.User.Commands;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Queries
{
    public class UserEditQuery : IRequest<IResponse<UserEditCommand>>
    {
        public int UserId { get; set; }

    }
}
