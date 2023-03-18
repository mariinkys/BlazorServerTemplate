using Application.Interfaces;
using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.Role.Queries;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.Role.Queries
{
    public class RoleEditQueryHandler : IRequestHandler<RoleEditQuery, IResponse<RoleEditCommand>>
    {

        private readonly IRoleRepository _repository;

        public RoleEditQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<RoleEditCommand>> Handle(RoleEditQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetByIdEditVM(request.RoleId);
            return new Response<RoleEditCommand>(x);
        }

    }
}
