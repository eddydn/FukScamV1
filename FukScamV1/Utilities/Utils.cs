using System.Text;

namespace FukScamV1.Utilities
{
    public static class Utils
    {
        static Random _random = new Random();
        public static string GenerateRandomTransactionNumberString()
        {
            int length = _random.Next(10, 19);

            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(_random.Next(10));
            }

            return builder.ToString();
        }

        public static string GenerateRandomOtpNumberString()
        {
           int length = _random.Next(6, 9);

            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(_random.Next(10));
            }

            return builder.ToString();
        }
    }
}
