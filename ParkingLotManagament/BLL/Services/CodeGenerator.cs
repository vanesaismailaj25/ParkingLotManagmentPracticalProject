using System.Text;
using XSystem.Security.Cryptography;

namespace ParkingLotManagament.BLL.Services
{
    public class CodeGenerator
    {
        public static string SubscribtionGenerateCode(DateTime startDate, int userId, int Subscriberid, decimal price, DateTime endDate)
        {
            // Concatenate the input values into a single string
            string inputString = $"{startDate.ToString("yyyyMMdd")}-{userId}--{Subscriberid}-{price.ToString("#.##")}-{endDate.ToString("yyyyMMdd")}";

            // Create a hash value from the input string
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hashBytes = new SHA256Managed().ComputeHash(inputBytes);

            // Convert the hash bytes to a hexadecimal string
            string code = BitConverter.ToString(hashBytes).Replace("-", "");

            // Return the resulting code
            return code;
        }

        public static string Subscriber(DateTime startDate, int userId, decimal price, DateTime endDate)
        {
            // Concatenate the input values into a single string
            string inputString = $"{startDate.ToString("yyyyMMdd")}-{userId}-{price.ToString("#.##")}-{endDate.ToString("yyyyMMdd")}";

            // Create a hash value from the input string
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hashBytes = new SHA256Managed().ComputeHash(inputBytes);

            // Convert the hash bytes to a hexadecimal string
            string code = BitConverter.ToString(hashBytes).Replace("-", "");

            // Return the resulting code
            return code;
        }

    }
}
