using Application.Shared.Features.User.Commands;
using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Interfaces;
using MediatR;
using Presentation.Shared.Managers;

namespace Presentation.Blazor.Server.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMediator _mediator;

        public UserManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResponse<int>> Edit(UserEditCommand query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<UserEditCommand>> GetById(UserEditQuery query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<IList<UsersListQueryVM>>> GetList(UsersListQuery query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<IList<UsersSelectorQueryVM>>> GetSelector(UsersSelectorQuery query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<bool>> UpdatePassword(UserUpdatePasswordCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
