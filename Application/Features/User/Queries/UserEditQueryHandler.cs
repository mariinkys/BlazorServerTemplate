using Application.Interfaces;
using Application.Shared.Features.User.Commands;
using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.User.Queries
{
    public class UserEditQueryHandler : IRequestHandler<UserEditQuery, IResponse<UserEditCommand>>
    {

        private readonly IUserRepository _repository;

        public UserEditQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<UserEditCommand>> Handle(UserEditQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetByIdEditVM(request.UserId);
            return new Response<UserEditCommand>(x);
        }

    }
}
