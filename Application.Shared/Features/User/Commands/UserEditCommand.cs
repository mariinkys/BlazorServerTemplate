using Application.Shared.Wrappers.Interfaces;
using MediatR;

namespace Application.Shared.Features.User.Commands
{
    public class UserEditCommand : IRequest<IResponse<int>>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surnames { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
