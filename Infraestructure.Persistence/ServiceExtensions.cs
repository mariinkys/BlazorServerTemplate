using Application.Interfaces;
using Infraestructure.Persistence.Contexts;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfraestructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDatabaseContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultProjectConnection")), ServiceLifetime.Transient);

            services = AddRepositories(services, configuration);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
