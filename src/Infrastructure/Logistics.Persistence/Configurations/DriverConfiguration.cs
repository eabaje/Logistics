using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Logistics.Persistence.Entities;

namespace Logistics.Persistence.Configurations
{
  
    public class DriverConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasKey(e => e.DriverId);

            //builder.Property(e => e.DriverId)
            //    .HasColumnName("DriverID")
            //    .HasMaxLength(5)
            //    .ValueGeneratedNever();

            //builder.Property(e => e.Address).HasMaxLength(60);

            //builder.Property(e => e.City).HasMaxLength(15);

            //builder.Property(e => e.DriverName)
            //    .IsRequired()
            //    .HasMaxLength(40);

            //builder.Property(e => e.Phone).HasMaxLength(30);

            //builder.Property(e => e.Email).HasMaxLength(30);

            //builder.Property(e => e.Country).HasMaxLength(15);

         
        }
    }
}
