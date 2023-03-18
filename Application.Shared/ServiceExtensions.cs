using Application.Shared.Features.Role.Commands;
using Application.Shared.Features.User.Commands;
using Application.Shared.Validators.Role;
using Application.Shared.Validators.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Shared
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserEditCommand>, UserValidator>();
            services.AddTransient<IValidator<UserUpdatePasswordCommand>, UserUpdatePasswordValidator>();
            services.AddTransient<IValidator<RoleEditCommand>, RoleValidator>();

            return services;
        }
    }
}
