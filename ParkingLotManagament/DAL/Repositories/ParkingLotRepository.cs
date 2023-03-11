using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
            ParkingLotManagementDatabaseContext _context;

            public ParkingLotRepository(ParkingLotManagementDatabaseContext databaseContext)
            {
                _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            }

            public async Task<int> Count()
            {
                var countedSpots = await _context.ParkingLots.CountAsync();
                return countedSpots;
            }

            public async Task<int> CountReserved()
            {
                var countedReservedSpots = await _context.ParkingLots.Where(x => x.SubscriptionId != null).CountAsync();
                return countedReservedSpots;
            }

            public async Task<ParkingLot> Edit(ParkingLot parkingLot)
            {
                _context.ParkingLots.Update(parkingLot);
                await _context.SaveChangesAsync();
                return parkingLot;
            }


            public async Task<ParkingLot> Get(int? id)
            {
                var spot = await _context.ParkingLots.FindAsync(id);
                return spot;
            }

            public async Task<IEnumerable<ParkingLot>> GetAll()
            {
                var spots = await _context.ParkingLots.ToListAsync();
                return spots;
            }
        }
    }

