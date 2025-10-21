using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;
using System.Reflection;

namespace Ordering.Infrastructure.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Customer>  Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<OrderItem> Orders => Set<OrderItem>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
