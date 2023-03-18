using Application.Interfaces;
using Application.Shared.Features.User.Commands;
using Application.Shared.Helpers;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Commands
{
    public class UserUpdatePasswordCommandHandler : IRequestHandler<UserUpdatePasswordCommand, IResponse<bool>>
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserUpdatePasswordCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResponse<bool>> Handle(UserUpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdForUpdate(request.UserId);
            if (user != null)
            {
                if (user.Password.Equals(PasswordHelper.Encrypt(request.OldPassword)))
                {
                    user.Password = PasswordHelper.Encrypt(request.NewPassword);
                    await _repository.UpdateAsync(user);
                    return new Response<bool>(true);
                }
                else
                {
                    return new Response<bool>("Las contraseña antigua no es correcta");
                }
            }
            else
            {
                return new Response<bool>("Error, no se ha encontrado el recurso con el Id: " + request.UserId);
            }
        }

    }
}
