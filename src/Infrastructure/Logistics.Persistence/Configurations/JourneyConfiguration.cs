using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Logistics.Persistence.Entities;

namespace Logistics.Persistence.Configurations
{
  
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("JourneyId")
                .HasMaxLength(5)
                .ValueGeneratedNever();



        //builder.Property(e => e.DriverName)
        //    .HasColumnName("Driver Name")
        //    .HasMaxLength(60);

            //builder.Property(e => e.).HasMaxLength(15);

            //builder.Property(e => e.CompanyName)
            //    .IsRequired()
            //    .HasMaxLength(40);

            builder.Property(e => e.VehicleId).HasMaxLength(30);

            builder.Property(e => e.JourneyStatus).HasMaxLength(30);

            builder.Property(e => e.StartLocation).HasMaxLength(15);

            builder.Property(e => e.Destination).HasMaxLength(24);

            builder.Property(e => e.TotalDistance).HasMaxLength(24);

            builder.Property(e => e.TravelTime).HasMaxLength(10);

            builder.Property(e => e.ReportsTo).HasMaxLength(15);
        }
    }
}
