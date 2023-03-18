using Application.Interfaces;
using Application.Shared.Features.User.Queries;
using Application.Shared.Helpers;
using Application.Shared.Wrappers.Implementations;
using Application.Shared.Wrappers.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.User.Queries
{
    public class UserCheckQueryHandler : IRequestHandler<UserCheckQuery, IResponse<string>>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public UserCheckQueryHandler(IUserRepository repository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<IResponse<string>> Handle(UserCheckQuery request, CancellationToken cancellationToken)
        {
            var x = await _repository.CheckUserAsync(request);

            if (x.HasValue)
            {
                var claims = await _roleRepository.GetClaimsByUserAsync((int)x);

                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, request.UserName));
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, request.UserName));
                claims.Add(new Claim(System.Security.Claims.ClaimTypes.Name, request.UserName));
                claims.Add(new Claim(System.Security.Claims.ClaimTypes.UserData, x.Value.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                return new Response<string>(TokenHelper.GenerateToken(_configuration, claims), null);
            }
            else
            {
                return new Response<string>("");
            }
        }

    }
}
