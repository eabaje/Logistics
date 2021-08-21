using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Logistics.Persistence.Entities;

namespace Logistics.Persistence.Configurations
{
  
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(e => e.ShipperId);

            //builder.Property(e => e.ShipperId)
            //    .HasColumnName("ShipperId")
            //    .HasMaxLength(5)
            //    .ValueGeneratedNever();

            //builder.Property(e => e.Address).HasMaxLength(60);

            //builder.Property(e => e.City).HasMaxLength(15);

            //builder.Property(e => e.ShipperName)
            //    .IsRequired()
            //    .HasMaxLength(40);

            //builder.Property(e => e.ContactName).HasMaxLength(30);

            //builder.Property(e => e.ContactTitle).HasMaxLength(30);

            //builder.Property(e => e.Country).HasMaxLength(15);

            //builder.Property(e => e.Fax).HasMaxLength(24);

            //builder.Property(e => e.Phone).HasMaxLength(24);

            //builder.Property(e => e.PostalCode).HasMaxLength(10);

            //builder.Property(e => e.Region).HasMaxLength(15);
        }
    }
}
