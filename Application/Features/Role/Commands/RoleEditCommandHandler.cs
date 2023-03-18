using Application.Interfaces;
using Application.Shared.Features.Role.Commands;
using Application.Shared.Helpers;
using Application.Shared.Validators.Role;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Role.Commands
{
    public class RoleEditCommandHandler : IRequestHandler<RoleEditCommand, IResponse<int>>
    {

        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;

        public RoleEditCommandHandler(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResponse<int>> Handle(RoleEditCommand request, CancellationToken cancellationToken)
        {
            var validator = new RoleValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0) return new Response<int>(ValidatorHelper.ParseFailures(validationResult.Errors.ToList()));

            if (request.Id == 0)
            {
                var entity = _mapper.Map<Domain.Entities.Role>(request);
                var x = await _repository.AddAsync(entity);
                return new Response<int>(x);
            }
            else
            {
                var x = await _repository.GetByIdForUpdate(request.Id);
                if (x != null)
                {
                    _mapper.Map(request, x, typeof(RoleEditCommand), typeof(Domain.Entities.Role));
                    await _repository.UpdateAsync(x);
                    return new Response<int>(x.Id);
                }
                else
                {
                    return new Response<int>("Error, no se ha encontrado el recurso con el Id: " + request.Id);
                }
            }
        }

    }
}
