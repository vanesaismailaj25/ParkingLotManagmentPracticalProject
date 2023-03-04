using Microsoft.EntityFrameworkCore;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        ParkingLotManagementDatabaseContext context;

        public LogRepository(ParkingLotManagementDatabaseContext _context)
        {
            context = _context;
        }

        public async Task<Log> CreateLog(Log log)
        {
            var newLog = await context.Logs.AddAsync(log);
            context.SaveChangesAsync();
            return newLog.Entity;
        }

        public async Task<Log> DeleteLog(int Id)
        {
            var log = await context.Logs.FindAsync(Id);
            context.Logs.Remove(log);
            context.SaveChangesAsync();
            return log;
        }

        public async Task<List<Log>> GetAllLogs()            
        {
            var logList = await context.Logs.ToListAsync();
            return logList;
        }

        public async Task<Log> GetLog(int Id)
        {
            var result = await context.Logs.FindAsync(Id);
            return result;
        }
    }
}
