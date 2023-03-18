using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Queries
{
    public class UserCheckQuery : IRequest<IResponse<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
