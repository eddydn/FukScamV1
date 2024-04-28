using System.Reflection;

namespace FukScamV1.Utilities
{
    public class FileUtils
    {
        private static Random _random = new Random();

        public static string GetResourceFilePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name must not be null or whitespace.", nameof(fileName));

            string? directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (directory == null)
                throw new InvalidOperationException("Cannot determine the directory of the executing assembly.");

            string filePath = Path.Combine(directory, "Resources", fileName);
            return filePath;
        }
        public static string GetRandomLineFromFile(string filePath)
        {
            var lines = File.ReadLines(filePath).ToList();
            if (lines.Count == 0)
                return string.Empty; // Trường hợp tệp trống

            int randomIndex = _random.Next(lines.Count);
            return lines[randomIndex];
        }
    }
}

