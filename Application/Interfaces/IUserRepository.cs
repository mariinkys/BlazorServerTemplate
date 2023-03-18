using Application.Shared.Features.User.Commands;
using Application.Shared.Features.User.Queries;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UsersListQueryVM>> GetList(UsersListQuery query);
        Task<List<UsersSelectorQueryVM>> GetSelector(UsersSelectorQuery query);
        Task<User> GetById(int id);
        Task<User> GetByIdForUpdate(int id);
        Task<UserEditCommand> GetByIdEditVM(int id);
        Task<int> AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task<int?> CheckUserAsync(UserCheckQuery query);
        Task<bool> CheckUserNameAsync(string username);
    }
}
