using System.Text;

namespace FukScamV1.Utilities
{
    public static class PhoneUtils
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _prefixes = {
        "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", // Viettel
        "091", "094", "088", "083", // Vinaphone
        "090", "093", "089", // Mobifone
        "092", "052", // Vietnamobile
        "099", // Gmobile
        "087" // Itelecom
    };

        /// <summary>
        /// Generates a random Vietnamese phone number.
        /// </summary>
        /// <returns>A random Vietnamese phone number string.</returns>
        public static string GenerateVietnamesePhoneNumber()
        {
            string prefix = _prefixes[_random.Next(_prefixes.Length)];

            StringBuilder number = new StringBuilder(10); 
            number.Append(prefix);
            for (int i = 0; i < 7; i++)
            {
                number.Append(_random.Next(10));
            }

            return number.ToString();
        }
    }
}
