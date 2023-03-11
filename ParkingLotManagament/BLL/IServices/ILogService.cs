using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.IServices;

public interface ILogService
{
    Task<LogViewModel> CreateLog(LogViewModel logViewModel);
    Task<LogViewModel> GetLog(int Id);
    Task<IEnumerable<LogViewModel>> GetAll();

}
