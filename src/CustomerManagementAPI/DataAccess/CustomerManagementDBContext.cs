using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pitstop.CustomerManagementAPI.Model;
using Polly;
using System;

namespace Pitstop.CustomerManagementAPI.DataAccess
{
    public class CustomerManagementDBContext : DbContext
    {
        public CustomerManagementDBContext()
        {

        }

        public CustomerManagementDBContext(DbContextOptions<CustomerManagementDBContext> options) : base(options)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5))
                .Execute(() => Database.Migrate());
        }
        
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(m => m.CustomerId);
            builder.Entity<Customer>().ToTable("Customer");
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // only used by EF tooling
        //    // TODO: make CN configurable
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("server=localhost:1434;user id=sa;password=Pinveco123;database=CustomerManagement;");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
