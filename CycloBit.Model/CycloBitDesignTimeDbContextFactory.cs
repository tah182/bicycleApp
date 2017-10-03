using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CycloBit.Model {
    public class CycloBitDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CycloBitContext> {
        public CycloBitContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<CycloBitContext>();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "local";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                .Build();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new CycloBitContext(builder.Options);
        }
    }
}