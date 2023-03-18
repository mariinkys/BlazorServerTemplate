using Application.Interfaces;
using Application.Shared.Features.Role.Queries;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Features.Role.Queries
{
    public class RolesListQueryHandler : IRequestHandler<RolesListQuery, IResponse<IList<RolesListQueryVM>>>
    {

        private readonly IRoleRepository _repository;

        public RolesListQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<IList<RolesListQueryVM>>> Handle(RolesListQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.GetList(request);
            return new Response<IList<RolesListQueryVM>>(x);
        }

    }
}
