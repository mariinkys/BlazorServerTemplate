using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.Role.Queries
{
    public class RolesListQuery : IRequest<IResponse<IList<RolesListQueryVM>>>
    {
        public int? UserId { get; set; }

    }
}
