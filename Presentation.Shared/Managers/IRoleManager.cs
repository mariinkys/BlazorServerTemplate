using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.Role.Queries;
using Application.Shared.Wrappers.Interfaces;

namespace Presentation.Shared.Managers
{
    public interface IRoleManager
    {
        //Task<IResponse<IList<HydroRolesSelectorQueryVM>>> GetSelector(HydroRolesSelectorQuery query);
        Task<IResponse<IList<RolesListQueryVM>>> GetList(RolesListQuery query);
        Task<IResponse<RoleEditCommand>> GetById(RoleEditQuery query);
        Task<IResponse<int>> Edit(RoleEditCommand query);
        Task<IResponse<bool>> EditUserRoles(EditUserRolesCommand query);
    }
}
