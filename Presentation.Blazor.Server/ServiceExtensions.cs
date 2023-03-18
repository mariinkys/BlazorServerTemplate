using Presentation.Blazor.Server.Managers;
using Presentation.Shared.Managers;

namespace Presentation.Blazor.Server
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IRoleManager, RoleManager>();

            return services;

        }
    }
}
