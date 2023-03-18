using Application.Shared.Features.Role.Commands;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.Role.Queries
{
    public class RoleEditQuery : IRequest<IResponse<RoleEditCommand>>
    {
        public int RoleId { get; set; }

    }
}
