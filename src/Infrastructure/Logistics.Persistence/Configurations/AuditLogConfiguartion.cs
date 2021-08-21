using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Logistics.Persistence.Entities;

namespace Logistics.Persistence.Configurations
{
  
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(5)
                .ValueGeneratedNever();
          
        builder.Property(e => e.Username).HasMaxLength(60);

            builder.Property(e => e.TableName).HasMaxLength(15);

            //builder.Property(e => e.CompanyName)
            //    .IsRequired()
            //    .HasMaxLength(40);

            builder.Property(e => e.Action).HasMaxLength(30);

            builder.Property(e => e.KeyValues).HasMaxLength(30);

            builder.Property(e => e.OldValues).HasMaxLength(15);

            builder.Property(e => e.NewValues).HasMaxLength(24);

           
        }
    }
}
