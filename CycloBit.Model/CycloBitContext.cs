using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CycloBit.Model.Entities;

namespace CycloBit.Model
{
    public class CycloBitContext : IdentityDbContext<ApplicationUser> {

        public CycloBitContext(DbContextOptions<CycloBitContext> options) : base(options) { }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema("CycloBit");
            builder.RemovePluralizingTableNameConvention();

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.Claims) 
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.Logins)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                   .HasMany(e => e.Roles)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public static class ModelBuilderExtensions {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder) {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes()) {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}