namespace Application.Shared.Features.User.Queries
{
    public class UsersSelectorQueryVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DisplayName
        {
            get => string.IsNullOrEmpty(FullName.Trim()) ? UserName : FullName + " (" + UserName + ")";
        }
    }
}
