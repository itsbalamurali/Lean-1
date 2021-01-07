using Microsoft.EntityFrameworkCore;
using QuantConnect.Configuration;
using QuantConnect.Orders;
using QuantConnect.Packets;

namespace QuantConnect.Persistence.Models
{
    public partial class LeanDbContext : DbContext
    {
        public virtual DbSet<BacktestResult> BacktestResult { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        //public virtual DbSet<ProfitLoss> ProfitLoss { get; set; }

        //public virtual DbSet<Chart> Chart { get; set; }

        //public virtual DbSet<Chart> Chart { get; set; }

        //public virtual DbSet<Chart> Chart { get; set; }

        public LeanDbContext()
        {
        }

        public LeanDbContext(DbContextOptions<LeanDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var hostname = Config.Get("Persistence.Database.HostName","localhost");
                var dbName = Config.Get("Persistence.Database.Name", "Lean");
                var dbUsername = Config.Get("Persistence.Database.Username", "postgres");
                var dbPassword = Config.Get("Persistence.Database.Password", "postgres");
                optionsBuilder.UseNpgsql("Host="+hostname+";Database="+dbName+ ";Username=" + dbUsername + ";Password=" + dbPassword + "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<BacktestResult>();
            modelBuilder.Entity<Chart>();
            modelBuilder.Entity<Order>();


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
