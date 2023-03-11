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
    [Migration("20230305111134_EditedCodeType")]
    partial class EditedCodeType
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
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<string>("ParkingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("ParkingLots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ParkingName = "A1"
                        },
                        new
                        {
                            Id = 2,
                            ParkingName = "A2"
                        },
                        new
                        {
                            Id = 3,
                            ParkingName = "A3"
                        },
                        new
                        {
                            Id = 4,
                            ParkingName = "A4"
                        },
                        new
                        {
                            Id = 5,
                            ParkingName = "B1"
                        },
                        new
                        {
                            Id = 6,
                            ParkingName = "B2"
                        },
                        new
                        {
                            Id = 7,
                            ParkingName = "B3"
                        },
                        new
                        {
                            Id = 8,
                            ParkingName = "B4"
                        },
                        new
                        {
                            Id = 9,
                            ParkingName = "C1"
                        },
                        new
                        {
                            Id = 10,
                            ParkingName = "C2"
                        },
                        new
                        {
                            Id = 11,
                            ParkingName = "C3"
                        },
                        new
                        {
                            Id = 12,
                            ParkingName = "C4"
                        });
                });

            modelBuilder.Entity("ParkingLotManagament.Models.PricingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DailyPricing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HourlyPricing")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan>("MinimumHours")
                        .HasColumnType("time");

                    b.Property<bool>("Weekend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PricingPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyPricing = 800m,
                            HourlyPricing = 100m,
                            MinimumHours = new TimeSpan(0, 0, 15, 0, 0),
                            Weekend = false
                        },
                        new
                        {
                            Id = 2,
                            DailyPricing = 500m,
                            HourlyPricing = 80m,
                            MinimumHours = new TimeSpan(0, 0, 15, 0, 0),
                            Weekend = true
                        });
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.ParkingLot", b =>
                {
                    b.HasOne("ParkingLotManagament.Models.Subscription", "Subscription")
                        .WithMany("ParkingLots")
                        .HasForeignKey("SubscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ParkingLotManagament.Models.Subscription", b =>
                {
                    b.HasOne("ParkingLotManagament.Models.Subscriber", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
