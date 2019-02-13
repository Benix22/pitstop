using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pitstop.Application.VehicleManagement.Model;
using Polly;
using System;

namespace Pitstop.Application.VehicleManagement.DataAccess
{
    public class VehicleManagementDBContext : DbContext
    {
        public VehicleManagementDBContext()
        {

        }

        public VehicleManagementDBContext(DbContextOptions<VehicleManagementDBContext> options) : base(options)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5))
                .Execute(() => Database.Migrate());
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Owner>().HasKey(m => m.OwnerId);
            builder.Entity<Owner>().ToTable("Owner");

            builder.Entity<Vehicle>().HasKey(m => m.Codigo);            
            builder.Entity<Vehicle>().ToTable("Vehicle");

            builder.Entity<Insurance>().HasKey(m => m.InsuranceId);
            builder.Entity<Insurance>().ToTable("Insurance");

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // only used by EF tooling
            // TODO: make CN configurable
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost:1434;user id=sa;password=Pinveco123;database=VehicleManagement;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
