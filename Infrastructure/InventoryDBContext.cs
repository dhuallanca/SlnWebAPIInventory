using Domain;
using Domain.Entities;
using Domain.Entities.Identity;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class InventoryDBContext(DbContextOptions<InventoryDBContext> options, IUserIdProvider userIdProvider) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userIdProvider.ToString();
                        entry.Entity.Created = DateTime.Now;

                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = userIdProvider.ToString();
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
