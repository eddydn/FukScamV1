using System.Text;

namespace FukScamV1.Extensions
{
    public static class StringExtensions
    {
        private static readonly Dictionary<char, char> UnicodeNormalizationMap = new Dictionary<char, char>
    {
        {'á', 'a'}, {'à', 'a'}, {'ả', 'a'}, {'ã', 'a'}, {'ạ', 'a'},
        {'â', 'a'}, {'ấ', 'a'}, {'ầ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'}, {'ậ', 'a'},
        {'ă', 'a'}, {'ắ', 'a'}, {'ằ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'}, {'ặ', 'a'},
        {'đ', 'd'},
        {'é', 'e'}, {'è', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'}, {'ẹ', 'e'},
        {'ê', 'e'}, {'ế', 'e'}, {'ề', 'e'}, {'ể', 'e'}, {'ễ', 'e'}, {'ệ', 'e'},
        {'í', 'i'}, {'ì', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'}, {'ị', 'i'},
        {'ó', 'o'}, {'ò', 'o'}, {'ỏ', 'o'}, {'õ', 'o'}, {'ọ', 'o'},
        {'ô', 'o'}, {'ố', 'o'}, {'ồ', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'}, {'ộ', 'o'},
        {'ơ', 'o'}, {'ớ', 'o'}, {'ờ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'}, {'ợ', 'o'},
        {'ú', 'u'}, {'ù', 'u'}, {'ủ', 'u'}, {'ũ', 'u'}, {'ụ', 'u'},
        {'ư', 'u'}, {'ứ', 'u'}, {'ừ', 'u'}, {'ử', 'u'}, {'ữ', 'u'}, {'ự', 'u'},
        {'ý', 'y'}, {'ỳ', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'}, {'ỵ', 'y'}
    };

        public static string NonUnicode(this string text)
        {
            StringBuilder normalizedText = new StringBuilder(text.Length);
            foreach (var character in text)
            {
                char normalizedChar = UnicodeNormalizationMap.TryGetValue(char.ToLower(character), out var replacement) ? replacement : character;
                normalizedText.Append(char.IsUpper(character) ? char.ToUpper(normalizedChar) : normalizedChar);
            }
            return normalizedText.ToString();
        }
    }
}
