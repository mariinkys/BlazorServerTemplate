using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Queries
{
    public class UsersSelectorQuery : IRequest<IResponse<IList<UsersSelectorQueryVM>>>
    {
    }
}
