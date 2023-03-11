using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.Models
{
    public partial class ParkingLotManagementDatabaseContext : DbContext
    {
        public ParkingLotManagementDatabaseContext()
        {
        }

        public ParkingLotManagementDatabaseContext(DbContextOptions<ParkingLotManagementDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<ParkingLot> ParkingLots { get; set; } = null!;
        public virtual DbSet<PricingPlan> PricingPlans { get; set; } = null!;
        public virtual DbSet<Subscriber> Subscribers { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Seed();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<ParkingLotManagament.ViewModels.SubscriptionViewModel> SubscriptionViewModel { get; set; }

    }
}
