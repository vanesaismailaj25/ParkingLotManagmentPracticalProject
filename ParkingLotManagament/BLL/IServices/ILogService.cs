using ParkingLotManagament.Models;

namespace ParkingLotManagament.BLL.IServices;

public interface ILogService
{
    Task<Log> CreateLog(Log log);
    Task<Log> DeleteLog(int Id);
    Task<Log> GetLog(int Id);
    Task<List<Log>> GetAllLog();

}
