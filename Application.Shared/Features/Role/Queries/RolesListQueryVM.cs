namespace Application.Shared.Features.Role.Queries
{
    public class RolesListQueryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //It should only be used when listing UserRoles
        public bool Selected { get; set; } = false;
    }
}
