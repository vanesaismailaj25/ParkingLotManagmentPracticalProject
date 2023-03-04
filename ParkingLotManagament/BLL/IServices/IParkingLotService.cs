using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;
using System.Diagnostics.Metrics;

namespace ParkingLotManagament.BLL.IServices
{
    public interface IParkingLotService
    {
        int CountReservedSpots();
        int CountSpots();
        Task<IEnumerable<ParkingDetailsViewModel>> GetAll();
        Task<ParkingDetailsViewModel> GetById(int id);
        Task<ParkingTableViewModel> CountAll();
        Task<ParkingDetailsViewModel> Edit(ParkingDetailsViewModel parkingView);
    }
}
