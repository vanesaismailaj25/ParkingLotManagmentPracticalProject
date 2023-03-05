using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository _logRepository)
        {
           logRepository = _logRepository;
        }

        public async Task<Log> CreateLog(Log log)
        {
            
            return await logRepository.CreateLog(log);
        }

        public async Task<Log> DeleteLog(int id)
        {
            return await logRepository.DeleteLog(id);
        }
       
        public async Task<List<Log>> GetAllLog()
        {
            return await logRepository.GetAllLogs();
        }

        public async Task<Log> GetLog(int Id)
        {
            return await logRepository.GetLog(Id);
        }
    }
}
