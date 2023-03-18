using Application.Interfaces;
using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.User.Queries
{
    public class UsersSelectorQueryHandler : IRequestHandler<UsersSelectorQuery, IResponse<IList<UsersSelectorQueryVM>>>
    {

        private readonly IUserRepository _repository;

        public UsersSelectorQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<IList<UsersSelectorQueryVM>>> Handle(UsersSelectorQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetSelector(request);
            return new Response<IList<UsersSelectorQueryVM>>(x);
        }

    }
}
