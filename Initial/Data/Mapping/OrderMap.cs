using Initial.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Initial.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            // Primary Key.
            builder.HasKey(t => t.OrderId);
            builder.Property(x => x.OrderId).HasColumnName("OrderId");

            builder.Property(t => t.UnitAmount).HasColumnName("UnitAmount").IsRequired();
            builder.Property(t => t.UnitPrice).HasColumnName("UnitPrice").IsRequired();
            builder.Property(t => t.TransactionAmount).HasColumnName("TransactionAmount").IsRequired();
            builder.Property(t => t.Direction).HasColumnName("Direction").IsRequired();
            builder.Property(t => t.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("CreatedDateTime");

            builder.HasOne(t => t.Batch).WithMany(x => x.Orders).HasForeignKey("BatchId");
        }
    }
}
