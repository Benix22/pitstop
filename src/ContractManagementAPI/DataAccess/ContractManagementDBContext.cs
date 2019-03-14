using Microsoft.EntityFrameworkCore;
using Pitstop.ContractManagementAPI.Model;
using Polly;
using System;

namespace Pitstop.ContractManagementAPI.DataAccess
{
    public class ContractManagementDBContext : DbContext
    {
        public ContractManagementDBContext()
        {
        }

        public ContractManagementDBContext(DbContextOptions<ContractManagementDBContext> options) : base(options)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5))
                .Execute(() => Database.Migrate());
        }

        public DbSet<Rate> Rates { get; set; }
        public DbSet<VAT> Vats { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rate>().HasKey(m => m.RateId);
            builder.Entity<Rate>().ToTable("Rate");

            builder.Entity<VAT>().HasKey(m => m.VatId);
            builder.Entity<VAT>().ToTable("VAT");

            builder.Entity<Contract>().HasKey(m => m.ContractId);
            builder.Entity<Contract>().ToTable("Contract");

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // only used by EF tooling
            // TODO: make CN configurable
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost,1434;user id=sa;password=Pinveco123;database=ContractManagement;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
