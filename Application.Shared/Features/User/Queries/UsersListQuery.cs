using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Queries
{
    public class UsersListQuery : IRequest<IResponse<IList<UsersListQueryVM>>>
    {
    }
}
