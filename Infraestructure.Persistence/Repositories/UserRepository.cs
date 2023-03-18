using Application.Interfaces;
using Application.Shared.Features.User.Commands;
using Application.Shared.Features.User.Queries;
using Domain.Entities;
using Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDatabaseContext _dbContext;

        public UserRepository(ProjectDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(User entity)
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public async Task<int?> CheckUserAsync(UserCheckQuery query)
        {
            var user = await _dbContext.Users.Where(x => x.UserName == query.UserName && x.Password == query.Password).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CheckUserNameAsync(string username)
        {
            var user = await _dbContext.Users.Where(x => x.UserName == username).AsNoTracking().FirstOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<UserEditCommand> GetByIdEditVM(int id)
        {
            return await _dbContext.Users.Where(x => x.Id.Equals(id)).Select(x => new UserEditCommand()
            {
                Id = x.Id,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Surnames = x.Surnames,
                Email = x.Email
            }).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdForUpdate(int id)
        {
            return await _dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<UsersListQueryVM>> GetList(UsersListQuery query)
        {
            return await _dbContext.Users.Select(x => new UsersListQueryVM()
            {
                Id = x.Id,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Surnames = x.Surnames,
                Email = x.Email,
                CreatedAt = x.CreatedAt
            }).AsNoTracking().ToListAsync();
        }

        public async Task<List<UsersSelectorQueryVM>> GetSelector(UsersSelectorQuery query)
        {
            return await _dbContext.Users.Select(x => new UsersSelectorQueryVM()
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.Name + " " + x.Surnames
            }).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
