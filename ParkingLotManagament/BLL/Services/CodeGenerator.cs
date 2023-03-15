
namespace ParkingLotManagament.BLL.Services
{
    public class CodeGenerator
    {
        public static string SubscribtionGenerateCode(DateTime startDate, int userId, int Subscriberid, DateTime endDate)
        {
            string random = GenerateRandomLetters(3);
            var code = $"{Subscriberid}-{startDate.ToString("yyyyMMdd")}-{userId}-{endDate.ToString("yyyyMMdd")}-{random}";
            return code;
        }

        public static string LogGenerateCode(DateTime checkintime,DateTime checkouttime,int id, int userId)
        {
            string random = GenerateRandomLetters(3);
            var code = $"{checkintime.ToString("yyyyMMdd")}-{checkouttime.ToString("yyyyMMdd")}-{id}-{userId}-{random}";
            return code;
        }
        static string GenerateRandomLetters(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
