﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingLotManagament.Models;

#nullable disable

namespace ParkingLotManagament.Migrations
{
    [DbContext(typeof(ParkingLotManagementDatabaseContext))]
    [Migration("20230219130027_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParkingLotManagament.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<string>("ParkingName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Parking Lot", (string)null);
                });

            modelBuilder.Entity("ParkingLotManagament.Models.PricingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DailyPricing")
                        .HasColumnType("money");

                    b.Property<decimal>("HourlyPricing")
                        .HasColumnType("money");

                    b.Property<DateTime>("MinimumHours")
                        .HasColumnType("datetime");

                    b.Property<bool>("Weekend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pricing Plans", (string)null);
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subscriber", (string)null);
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("DiscountValue")
                        .HasColumnType("money");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("SubscriberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Log", b =>
                {
                    b.HasOne("ParkingLotManagament.Models.Subscription", "Subscription")
                        .WithMany("Logs")
                        .HasForeignKey("SubscriptionId")
                        .IsRequired()
                        .HasConstraintName("FK_Logs_Subscriptions");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.ParkingLot", b =>
                {
                    b.HasOne("ParkingLotManagament.Models.Subscription", "Subscription")
                        .WithMany("ParkingLots")
                        .HasForeignKey("SubscriptionId")
                        .HasConstraintName("FK_Parking Lot_Subscriptions");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscription", b =>
                {
                    b.HasOne("ParkingLotManagament.Models.Subscriber", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .IsRequired()
                        .HasConstraintName("FK_Subscriptions_Subscriber");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscriber", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscription", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("ParkingLots");
                });
#pragma warning restore 612, 618
        }
    }
}