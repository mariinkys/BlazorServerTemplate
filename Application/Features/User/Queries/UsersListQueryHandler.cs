using Application.Interfaces;
using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.User.Queries
{
    public class UsersListQueryHandler : IRequestHandler<UsersListQuery, IResponse<IList<UsersListQueryVM>>>
    {

        private readonly IUserRepository _repository;

        public UsersListQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<IList<UsersListQueryVM>>> Handle(UsersListQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetList(request);
            return new Response<IList<UsersListQueryVM>>(x);
        }

    }
}
