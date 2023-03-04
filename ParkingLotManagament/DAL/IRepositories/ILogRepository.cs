using ParkingLotManagament.Models;

namespace ParkingLotManagament.DAL.IRepositories
{
    public interface ILogRepository
    {
        Task<Log> CreateLog(Log log);
        Task<Log> DeleteLog(int Id);
        Task<Log> GetLog(int Id);
        Task<List<Log>> GetAllLogs();
    }
}
