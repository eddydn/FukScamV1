using HtmlAgilityPack;

namespace FukScamV1.Helpers
{
    public static class Helper
    {
        public static void WriteToConsole(string content, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }


        public static string? ExtractCSRFToken(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return null;

            var document = new HtmlDocument();
            document.LoadHtml(html);

            var tokenElement = document.DocumentNode.SelectSingleNode("//input[@name='_token']");
            if (tokenElement != null)
            {
                return tokenElement.GetAttributeValue("value", null);
            }

            return null;
        }
    }
}
