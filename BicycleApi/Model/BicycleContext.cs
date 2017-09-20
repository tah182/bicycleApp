using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BicycleApi.Model {
    public class BicycleContext : DbContext {

        public BicycleContext(DbContextOptions<BicycleContext> options) : base(options) { }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.HasDefaultSchema("Bicycle");
            builder.RemovePluralizingTableNameConvention();

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