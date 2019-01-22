using Microsoft.EntityFrameworkCore;
using Pitstop.ContractManagementAPI.Model;
using Polly;
using System;

namespace Pitstop.ContractManagementAPI.DataAccess
{
    public class ContractManagementDBContext: DbContext
    {
        public ContractManagementDBContext(DbContextOptions<ContractManagementDBContext> options) : base(options)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5))
                .Execute(() => Database.Migrate());
        }

        public DbSet<Tarifa> Tarifas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tarifa>().HasKey(m => m.TarifaId);
            builder.Entity<Tarifa>().ToTable("Tarifa");
            base.OnModelCreating(builder);
        }
    }
}
