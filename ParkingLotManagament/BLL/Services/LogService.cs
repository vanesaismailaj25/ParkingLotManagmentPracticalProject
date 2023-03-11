using AutoMapper;
using ParkingLotManagament.BLL.IServices;
using ParkingLotManagament.DAL.IRepositories;
using ParkingLotManagament.Models;
using ParkingLotManagament.ViewModels;

namespace ParkingLotManagament.BLL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        private readonly CodeGenerator _codeGenerator;
        private readonly IMapper _mapper;

        public LogService(ILogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _codeGenerator = new CodeGenerator();
            _mapper = mapper;
        }

        public async Task<LogViewModel> CreateLog(LogViewModel logViewModel)
        {
            if (logViewModel == null)
            {
                throw new ArgumentNullException(nameof(logViewModel));
            }
            if (logViewModel.CheckInTime > logViewModel.CheckOutTime)
            {
                throw new ArgumentException("Check Out Time must be greater than Check In Time.", nameof(logViewModel.CheckOutTime));
            }
            var code = CodeGenerator.LogGenerateCode(
                logViewModel.CheckInTime,
                logViewModel.CheckOutTime,
                logViewModel.Id,
                logViewModel.SubscriptionId);

            var newLog = new Log
            {
                Id = logViewModel.Id,
                Code = code,
                SubscriptionId = logViewModel.SubscriptionId,
                CheckInTime = logViewModel.CheckInTime,
                CheckOutTime = logViewModel.CheckOutTime,
                Price = logViewModel.Price,
            };
            var result = await _repository.CreateLog(newLog);
            return new LogViewModel
            {
                Id = result.Id,
                SubscriptionId = result.SubscriptionId,
                CheckInTime = result.CheckInTime,
                CheckOutTime = result.CheckOutTime,
                Price = result.Price,
            };
        }



        public async Task<IEnumerable<LogViewModel>> GetAll()
        {
            var result = await _repository.GetAllLogs();
            var mappedResult = _mapper.Map<IEnumerable<LogViewModel>>(result);
            return mappedResult;
        }

        public async Task<LogViewModel> GetLog(int Id)
        {
            var result = await _repository.GetLog(Id);
            var mappedResult = _mapper.Map<LogViewModel>(result);
            return mappedResult;

        }
    }
}
