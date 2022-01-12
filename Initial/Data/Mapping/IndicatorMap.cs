using Initial.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Initial.Data.Mapping
{
    public class IndicatorMap : IEntityTypeConfiguration<Indicator>
    {
        public void Configure(EntityTypeBuilder<Indicator> builder)
        {
            builder.ToTable("Indicator");

            // Primary Key.
            builder.HasKey(t => t.IndicatorId);
            builder.Property(x => x.IndicatorId).HasColumnName("IndicatorId");

            builder.Property(t => t.Name).HasColumnName("IndicatorName").IsRequired();
            builder.Property(t => t.TimeInterval).HasColumnName("TimeInterval").IsRequired();
            builder.Property(t => t.Direction).HasColumnName("Direction").IsRequired();
            builder.Property(t => t.Price).HasColumnName("Price").IsRequired();
            builder.Property(t => t.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("CreatedDateTime");

            builder.HasOne(t => t.Batch).WithMany(x => x.Indicators).HasForeignKey("BatchId");
        }
    }
}
