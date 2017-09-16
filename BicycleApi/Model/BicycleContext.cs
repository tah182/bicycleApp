using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BicycleApi.Model
{
    public class BicycleContext : DbContext
    {
        public BicycleContext(DbContextOptions<BicycleContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}