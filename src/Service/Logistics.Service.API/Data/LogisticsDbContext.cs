using Microsoft.EntityFrameworkCore;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Data
{
   public class LogisticsDbContext: IdentityDbContext<AppUser>
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
           : base(options)
        {

            this.loggerFactory = loggerFactory;
            this.httpContextAccessor = httpContextAccessor;
        }

        public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : base(options)
        {
        }

        


        public DbSet<Category> Categories { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Consignment> Consignments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AssignVehicle> AssignVehicles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<VehicleDriver> Drivers { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        // public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var temoraryAuditEntities = await AuditNonTemporaryProperties();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await AuditTemporaryProperties(temoraryAuditEntities);
            return result;
        }


        async Task<IEnumerable<Tuple<EntityEntry, AuditLog>>> AuditNonTemporaryProperties()
        {
            ChangeTracker.DetectChanges();
            var entitiesToTrack = ChangeTracker.Entries().Where(e => !(e.Entity is AuditLog) && e.State != EntityState.Detached && e.State != EntityState.Unchanged);

            await AuditLogs.AddRangeAsync(
                entitiesToTrack.Where(e => !e.Properties.Any(p => p.IsTemporary)).Select(e => new AuditLog()
                {
                    TableName = e.Metadata.Relational().TableName,
                    Action = Enum.GetName(typeof(EntityState), e.State),
                    AuditDate = DateTime.Now.ToUniversalTime(),
                    Username = this.httpContextAccessor?.HttpContext?.User?.Identity?.Name,
                    KeyValues = JsonConvert.SerializeObject(e.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    NewValues = JsonConvert.SerializeObject(e.Properties.Where(p => e.State == EntityState.Added || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    OldValues = JsonConvert.SerializeObject(e.Properties.Where(p => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.OriginalValue).NullIfEmpty())
                }).ToList()
            );

            //Return list of pairs of EntityEntry and ToolAudit  
            return entitiesToTrack.Where(e => e.Properties.Any(p => p.IsTemporary))
                 .Select(e => new Tuple<EntityEntry, AuditLog>(
                     e,
                 new AuditLog()
                 {
                     TableName = e.Metadata.Relational().TableName,
                     Action = Enum.GetName(typeof(EntityState), e.State),
                     AuditDate = DateTime.Now.ToUniversalTime(),
                     Username = this.httpContextAccessor?.HttpContext?.User?.Identity?.Name,
                     NewValues = JsonConvert.SerializeObject(e.Properties.Where(p => !p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty())
                 }
                 )).ToList();
        }

        async Task AuditTemporaryProperties(IEnumerable<Tuple<EntityEntry, AuditLog>> temporatyEntities)
        {
            if (temporatyEntities != null && temporatyEntities.Any())
            {
                await AuditLogs.AddRangeAsync(
                temporatyEntities.ForEach(t => t.Item2.KeyValues = JsonConvert.SerializeObject(t.Item1.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()))
                    .Select(t => t.Item2)
                );
                await SaveChangesAsync();
            }
            await Task.CompletedTask;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             // modelBuilder.ApplyAllConfigurations();

            base.OnModelCreating(modelBuilder);
        }





      
    }
}
