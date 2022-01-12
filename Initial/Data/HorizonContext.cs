using Initial.Data.Mapping;
using Initial.Domain;
using Microsoft.EntityFrameworkCore;

namespace Initial.Data
{
    public sealed class HorizonContext : DbContext
    {
        public HorizonContext(DbContextOptions<HorizonContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(120);
        }

        public DbSet<Batch> BatchRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BatchMap());
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
