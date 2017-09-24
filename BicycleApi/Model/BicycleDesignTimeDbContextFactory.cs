using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BicycleApi.Model {
    public class BicycleDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BicycleContext> {
        public BicycleContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<BicycleContext>();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "local";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: false)
                .Build();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new BicycleContext(builder.Options);
        }
    }
}