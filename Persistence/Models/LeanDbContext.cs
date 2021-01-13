using Microsoft.EntityFrameworkCore;
using QuantConnect.Configuration;
using QuantConnect.Interfaces;
using QuantConnect.Orders;
using QuantConnect.Packets;

namespace QuantConnect.Persistence.Models
{
    public partial class LeanDbContext : DbContext
    {
        public virtual DbSet<BacktestResult> BacktestResult { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        public virtual DbSet<OrderSubmissionData> OrderSubmissionData { get; set; }

        //public virtual DbSet<SecurityIdentifier> SecurityIdentifier { get; set; }

        public virtual DbSet<Symbol> Symbol { get; set; }
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

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<AuthorModel, AuthorDTO>();
            //});
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<BacktestResult>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Chart>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Order>().HasOne<OrderSubmissionData>();
            modelBuilder.Entity<Order>().HasOne<Symbol>(o => o.Symbol);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Ignore(o => o.Symbol);
            });



            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.HasOne(order => order.Symbol)
            //        .WithOne(course => course.Customer)
            //        .HasForeignKey<Course>(course => course.Id);
            //});
            //modelBuilder.Entity<Student>()
            //.HasOne<StudentAddress>(s => s.Address)
            //.WithOne(ad => ad.Student)
            //.HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            modelBuilder.Ignore<IOrderProperties>();
            modelBuilder.Ignore<OrderSubmissionData>();
            //modelBuilder.Ignore<SecurityIdentifier>();

            modelBuilder.Entity<SecurityIdentifier>(eb =>
            {
                eb.Ignore(si =>si.Symbol);
            });
            modelBuilder.Entity<Symbol>().HasNoKey();


            modelBuilder.Entity<SecurityIdentifier>().HasKey(si => new { si.Symbol});

            modelBuilder.Entity<Symbol>().Property(s=>s.ID).IsRequired();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
