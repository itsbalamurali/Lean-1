using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuantConnect.Persistence.Models
{
    public partial class LeanDbContext : DbContext
    {
        public virtual DbSet<DbBacktestResult> DbBacktestResult { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Lean;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<DbBacktestResult>();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
