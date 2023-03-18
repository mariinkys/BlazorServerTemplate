using Application.Shared.Features.Role.Queries;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.Role.Commands
{
    public class EditUserRolesCommand : IRequest<IResponse<bool>>
    {
        public int UserId { get; set; }
        public List<RolesListQueryVM> CurrentModel { get; set; }

    }
}
