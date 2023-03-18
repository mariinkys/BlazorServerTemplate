using Application.Interfaces;
using Application.Shared.Features.Role.Commands;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.Role.Commands
{
    public class EditUserRolesCommandHandler : IRequestHandler<EditUserRolesCommand, IResponse<bool>>
    {

        private readonly IRoleRepository _repository;

        public EditUserRolesCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<bool>> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            var x = await _repository.EditUserRoles(request);
            return new Response<bool>(x);
        }

    }
}
