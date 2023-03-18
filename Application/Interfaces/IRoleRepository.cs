using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.Role.Queries;
using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RolesListQueryVM>> GetList(RolesListQuery query);
        //Task<List<RolesSelectorQueryVM>> GetSelector(RolesSelectorQuery query);
        Task<Role> GetById(int id);
        Task<Role> GetByIdForUpdate(int id);
        Task<RoleEditCommand> GetByIdEditVM(int id);
        Task<int> AddAsync(Role entity);
        Task UpdateAsync(Role entity);
        Task<List<Claim>> GetClaimsByUserAsync(int UserId);
        Task<bool> EditUserRoles(EditUserRolesCommand query);
    }
}
