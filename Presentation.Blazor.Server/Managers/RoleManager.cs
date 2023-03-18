using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.Role.Queries;
using Application.Shared.Wrappers.Interfaces;
using MediatR;
using Presentation.Shared.Managers;

namespace Presentation.Blazor.Server.Managers
{
    public class RoleManager : IRoleManager
    {
        private readonly IMediator _mediator;

        public RoleManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResponse<int>> Edit(RoleEditCommand query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<bool>> EditUserRoles(EditUserRolesCommand query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<RoleEditCommand>> GetById(RoleEditQuery query)
        {
            return await _mediator.Send(query);
        }

        public async Task<IResponse<IList<RolesListQueryVM>>> GetList(RolesListQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
