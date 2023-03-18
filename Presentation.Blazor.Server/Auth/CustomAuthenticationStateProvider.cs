using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Interfaces;
using Blazored.LocalStorage;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Presentation.Shared.Managers;
using System.Security.Claims;
using System.Text.Json;

namespace Presentation.Blazor.Server.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider, IAccountManager
    {
        public static readonly string TOKENKEY = "TOKENKEY";
        private readonly ILocalStorageService _localStorage;
        private readonly IMediator _mediator;

        public CustomAuthenticationStateProvider(IMediator mediator, ILocalStorageService localStorage)
        {
            _mediator = mediator;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("BASE-" + TOKENKEY);
            if (string.IsNullOrEmpty(token)) return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            return BuildAuthenticationState(token);
        }

        private async Task Clean()
        {
            await _localStorage.RemoveItemAsync("BASE-" + TOKENKEY);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            if (token is null) return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }
        public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            //TODO: The only claim that gets parsed is the role, gotta fix that (This code below attemps to fix that)
            foreach (var keyValue in keyValuePairs)
            {
                if (keyValue.Key != ClaimTypes.Role)
                {
                    if (keyValue.Key.Equals(ClaimTypes.Name))
                    {
                        if (!string.IsNullOrEmpty(keyValue.Value.ToString())) claims.Add(new Claim(ClaimTypes.Name, keyValue.Value.ToString()));
                    }
                    if (keyValue.Key.Equals(ClaimTypes.UserData))
                    {
                        if (!string.IsNullOrEmpty(keyValue.Value.ToString())) claims.Add(new Claim(ClaimTypes.UserData, keyValue.Value.ToString()));
                    }
                }
            }


            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        public async Task<ClaimsPrincipal> GetAuthenticationStateProviderUserAsync()
        {
            var state = await this.GetAuthenticationStateAsync();
            var authenticationStateProviderUser = state.User;
            return authenticationStateProviderUser;
        }
        public async Task<IEnumerable<Claim>> GetClaimsFromCurrentTokenAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("BASE-" + TOKENKEY);
            if (token == null) return Enumerable.Empty<Claim>();
            return ParseClaimsFromJwt(token);
        }
        public async Task<bool> CheckIfTokenHasClaim(string ApplicationClaimType, string claim)
        {
            var token = await _localStorage.GetItemAsStringAsync("BASE-" + TOKENKEY);
            if (token == null) return false;
            return ParseClaimsFromJwt(token).Where(x => x.Type == ApplicationClaimType && x.Value == claim).Any();
        }
        public async Task<IResponse<string>> Login(string username, string password)
        {

            password = Application.Shared.Helpers.PasswordHelper.Encrypt(password);
            var UserCheckQuery = new UserCheckQuery { UserName = username, Password = password };
            var res = await _mediator.Send(UserCheckQuery);

            if (res.Succeeded && !string.IsNullOrEmpty(res.Data))
            {
                await _localStorage.SetItemAsStringAsync("BASE-" + TOKENKEY, res.Data);
                var authState = BuildAuthenticationState(res.Data);
                NotifyAuthenticationStateChanged(Task.FromResult(authState));
            }
            return res;
        }
        public async Task Logout()
        {
            await Clean();
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
