using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pitstop.Application.VehicleManagement.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitstop.Application.VehicleManagement.DataAccess
{
    public class VehicleManagementDBContext : DbContext
    {
        public VehicleManagementDBContext(DbContextOptions<VehicleManagementDBContext> options) : base(options)
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(5, r => TimeSpan.FromSeconds(5))
                .Execute(() => Database.Migrate());
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Owner>().HasKey(m => m.OwnerId);
            builder.Entity<Owner>().ToTable("Owner");

            builder.Entity<Vehicle>().HasKey(m => m.Codigo);            
            builder.Entity<Vehicle>().ToTable("Vehicle");

            base.OnModelCreating(builder);
        }
    }
}
