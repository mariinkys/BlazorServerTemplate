using Application.Shared.Features.User.Commands;
using Application.Shared.Features.User.Queries;
using Application.Shared.Wrappers.Interfaces;

namespace Presentation.Shared.Managers
{
    public interface IUserManager
    {
        Task<IResponse<IList<UsersSelectorQueryVM>>> GetSelector(UsersSelectorQuery query);
        Task<IResponse<IList<UsersListQueryVM>>> GetList(UsersListQuery query);
        Task<IResponse<UserEditCommand>> GetById(UserEditQuery query);
        Task<IResponse<int>> Edit(UserEditCommand query);
        Task<IResponse<bool>> UpdatePassword(UserUpdatePasswordCommand command);
    }
}
