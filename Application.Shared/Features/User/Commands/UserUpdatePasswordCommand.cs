using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Commands
{
    public class UserUpdatePasswordCommand : IRequest<IResponse<bool>>
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
