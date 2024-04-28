using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;

namespace VietnameseNameGenerator
{
    public static class Helper
    {
        static Random _random = new Random();
        public static void ConvertJsonToText(string jsonInputPath, string textOutputPath)
        {
           var jsonData = File.ReadAllText(jsonInputPath);
            JArray jsonArray = JArray.Parse(jsonData);

            using (StreamWriter file = new StreamWriter(textOutputPath))
            {
                foreach (JObject obj in jsonArray)
                {
                    string fullName = obj["full_name"].ToString();
                    string processedName = ProcessName(fullName) + (_random.Next(10));
                    file.WriteLine(processedName);
                }
            }
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        static string ProcessName(string fullName)
        {
            string withoutDiacritics = RemoveDiacritics(fullName);
            string[] parts = withoutDiacritics.Split(' ');

            if (parts.Length >= 4)
            {
                string first = parts[0];
                string middle = string.Concat(parts[1].Take(1));
                string last = string.Join("", parts.Skip(2));
                return (first + middle + last).ToLower().Replace(" ", "");
            }
            else
            {
                return withoutDiacritics.ToLower().Replace(" ", "");
            }
        }
    }

}

