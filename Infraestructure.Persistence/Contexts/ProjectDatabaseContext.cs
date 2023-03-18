using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Contexts
{
    public class ProjectDatabaseContext : DbContext
    {
        public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => { e.ToTable(name: "Users", "Security"); });
            modelBuilder.Entity<Role>(e => { e.ToTable(name: "Roles", "Security"); });
            modelBuilder.Entity<UserRole>(e => { e.ToTable(name: "UserRoles", "Security"); });
            modelBuilder.Entity<UserRole>().HasKey(k => new {k.UserId, k.RoleId});


            //TEMPORAL SEEDS
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "ADMIN" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "USER" });
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "DefaultUser", Password = Application.Shared.Helpers.PasswordHelper.Encrypt("default123@") });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { UserId = 1, RoleId = 1 });


        }
    }
}
