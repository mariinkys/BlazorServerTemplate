using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.User.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEditCommand>().ReverseMap();
            CreateMap<Role, RoleEditCommand>().ReverseMap();
        }
    }
}
