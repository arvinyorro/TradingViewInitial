using Initial.Data.Mapping;
using Initial.Domain;
using Microsoft.EntityFrameworkCore;

namespace Initial.Data
{
    public sealed class BinanceBotContext : DbContext
    {
        public BinanceBotContext(DbContextOptions<BinanceBotContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(120);
        }

        public DbSet<Batch> BatchRepository { get; set; }
        public DbSet<Indicator> IndicatorRepository { get; set; }
        public DbSet<Order> OrderRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BatchMap());
            modelBuilder.ApplyConfiguration(new IndicatorMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
        }

        public bool HasDatabaseConnection()
        {
            try
            {
                base.Database.ExecuteSqlRaw($"SELECT 1");
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
