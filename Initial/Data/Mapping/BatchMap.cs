using Initial.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Initial.Data.Mapping
{
    public class BatchMap : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batch");

            // Primary Key.
            builder.HasKey(t => t.BatchId);
            builder.Property(x => x.BatchId).HasColumnName("BatchId");

            builder.Property(t => t.TradingSymbol).HasColumnName("TradingSymbol").IsRequired();
            builder.Property(t => t.CapitalAmount).HasColumnName("CapitalAmount").IsRequired();
            builder.Property(t => t.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("CreatedDateTime");
            builder.Property(t => t.Active).HasDefaultValueSql("1").HasColumnName("Active");

            //builder.Property<long>("ApplicationId").HasField("_applicationId").HasColumnName("ApplicationId");
        }
    }
}
