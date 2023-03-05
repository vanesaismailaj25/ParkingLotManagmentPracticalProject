using Microsoft.EntityFrameworkCore;

namespace ParkingLotManagament.Models
{
    public static class ModelBuilderExtension
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<ParkingLot>().HasData(
               new ParkingLot
               {
                   Id = 1,
                   ParkingName = "A1"
               },
               new ParkingLot
               {
                   Id = 2,
                   ParkingName = "A2"
               }, new ParkingLot
               {
                   Id = 3,
                   ParkingName = "A3"
               }, new ParkingLot
               {
                   Id = 4,
                   ParkingName = "A4"
               }, new ParkingLot
               {
                   Id = 5,
                   ParkingName = "B1"
               }, new ParkingLot
               {
                   Id = 6,
                   ParkingName = "B2"
               }, new ParkingLot
               {
                   Id = 7,
                   ParkingName = "B3"
               }, new ParkingLot
               {
                   Id = 8,
                   ParkingName = "B4"
               }, new ParkingLot
               {
                   Id = 9,
                   ParkingName = "C1"
               }, new ParkingLot
               {
                   Id = 10,
                   ParkingName = "C2"
               }, new ParkingLot
               {
                   Id = 11,
                   ParkingName = "C3"
               }, new ParkingLot
               {
                   Id = 12,
                   ParkingName = "C4"
               });
            _ = modelBuilder.Entity<PricingPlan>().HasData(
                new PricingPlan
                {
                    Id = 1,
                    HourlyPricing = 100,
                    DailyPricing = 800,
                    MinimumHours = DateTime.Now.AddMinutes(15),
                    Weekend = false
                },
                new PricingPlan
                {
                    Id = 2,
                    HourlyPricing = 80,
                    DailyPricing = 500,
                    MinimumHours = DateTime.Now.AddMinutes(15),
                    Weekend = true
                });

        }
    }
}
