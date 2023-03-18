using Application.Interfaces;
using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.Role.Queries;
using Domain.Entities;
using Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ProjectDatabaseContext _dbContext;

        public RoleRepository(ProjectDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Role entity)
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public async Task<bool> EditUserRoles(EditUserRolesCommand query)
        {
            //TODO: Improvments, is not good practice to delete all current user roles and assing new ones.
            try
            {
                var userRoles = await _dbContext.UserRoles.Where(x => x.UserId == query.UserId).AsNoTracking().ToListAsync();
                foreach (var role in userRoles)
                {
                    _dbContext.UserRoles.Remove(role);
                }
                foreach (var role in query.CurrentModel)
                {
                    if (role.Selected) _dbContext.UserRoles.Add(new UserRole { UserId = query.UserId, RoleId = role.Id });
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Role> GetById(int id)
        {
            return await _dbContext.Roles.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<RoleEditCommand> GetByIdEditVM(int id)
        {
            return await _dbContext.Roles.Where(x => x.Id.Equals(id)).Select(x => new RoleEditCommand()
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Role> GetByIdForUpdate(int id)
        {
            return await _dbContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Claim>> GetClaimsByUserAsync(int UserId)
        {
            var claims = new List<Claim>();
            var userRoles = await _dbContext.UserRoles.Where(x => x.UserId == UserId).ToListAsync();
            if (userRoles != null && userRoles.Any())
            {
                foreach (var role in userRoles)
                {
                    var roleModel = await _dbContext.Roles.Where(x => x.Id == role.RoleId).FirstOrDefaultAsync();
                    claims.Add(new Claim(ClaimTypes.Role, roleModel.Name));
                }
            }

            return claims;
        }

        public async Task<List<RolesListQueryVM>> GetList(RolesListQuery query)
        {
            var roles = await _dbContext.Roles.Select(x => new RolesListQueryVM()
            {
                Id = x.Id,
                Name = x.Name
            }).AsNoTracking().ToListAsync();

            if (query.UserId.HasValue)
            {
                var allUserRoles = await _dbContext.UserRoles.Where(x => x.UserId.Equals(query.UserId)).AsNoTracking().ToListAsync();
                foreach (var role in roles)
                {
                    foreach (var userRole in allUserRoles)
                    {
                        if (userRole.RoleId.Equals(role.Id)) role.Selected = true;
                    }
                }
            }

            return roles;
        }

        public async Task UpdateAsync(Role entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
