
namespace ParkingLotManagament.BLL.Services
{
    public class CodeGenerator
    {
        public static string SubscribtionGenerateCode(DateTime startDate, int userId, int Subscriberid, decimal price, DateTime endDate)
        {
            var code = $"{Subscriberid}-{startDate.ToString("yyyyMMdd")}-{userId}-{price.ToString("F2")}-{endDate.ToString("yyyyMMdd")}";
            return code;
        }

        public static string Subscriber(DateTime startDate, int userId, decimal price, DateTime endDate)
        {
            var code = $"{startDate.ToString("yyyyMMdd")}-{userId}-{price.ToString("F2")}-{endDate.ToString("yyyyMMdd")}";
            return code;
        }

    }
}
