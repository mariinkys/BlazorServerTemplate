using Application.Interfaces;
using Application.Shared.Features.User.Commands;
using Application.Shared.Helpers;
using Application.Shared.Validators.User;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands
{
    public class UserEditCommandHandler : IRequestHandler<UserEditCommand, IResponse<int>>
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserEditCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResponse<int>> Handle(UserEditCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0) return new Response<int>(ValidatorHelper.ParseFailures(validationResult.Errors.ToList()));

            if (request.Id == 0)
            {
                var res = await _repository.CheckUserNameAsync(request.UserName);
                if (res)
                {
                    return new Response<int>("Error, ya existe un usuario con el nombre " + request.UserName);
                }
                else
                {
                    request.Password = PasswordHelper.Encrypt(request.Password);
                    var entity = _mapper.Map<Domain.Entities.User>(request);
                    var x = await _repository.AddAsync(entity);
                    return new Response<int>(x);
                }
            }
            else
            {
                var x = await _repository.GetByIdForUpdate(request.Id);
                if (x != null)
                {
                    _mapper.Map(request, x, typeof(UserEditCommand), typeof(Domain.Entities.User));
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
