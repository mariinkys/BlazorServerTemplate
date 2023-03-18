using Application.Shared.Wrappers.Interfaces;

namespace Presentation.Shared.Managers
{
    public interface IAccountManager
    {
        Task<IResponse<string>> Login(string username, string password);
        Task Logout();
    }
}
