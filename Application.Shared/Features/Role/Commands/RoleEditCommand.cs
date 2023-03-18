using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.Role.Commands
{
    public class RoleEditCommand : IRequest<IResponse<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
