using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2J47R00;Database=ParkingLotManagementDatabase;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.CheckInTime).HasColumnType("datetime");

                entity.Property(e => e.CheckOutTime).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logs_Subscriptions");
            });

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.ToTable("Parking Lot");

                entity.Property(e => e.ParkingName).HasMaxLength(50);

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.ParkingLots)
                    .HasForeignKey(d => d.SubscriptionId)
                    .HasConstraintName("FK_Parking Lot_Subscriptions");
            });

            modelBuilder.Entity<PricingPlan>(entity =>
            {
                entity.ToTable("Pricing Plans");

                entity.Property(e => e.DailyPricing).HasColumnType("money");

                entity.Property(e => e.HourlyPricing).HasColumnType("money");

                entity.Property(e => e.MinimumHours).HasColumnType("datetime");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.ToTable("Subscriber");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdCardNumber).HasMaxLength(12);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.PlateNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.DiscountValue).HasColumnType("money");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.SubscriberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscriptions_Subscriber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
