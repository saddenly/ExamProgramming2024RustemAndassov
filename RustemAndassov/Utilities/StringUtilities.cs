using System.Text;

namespace Utilities
{
    public static class StringUtilities
    {
        public static int LongWordsCount(string str)
        {
            string[] words = str.Split(' ');
            int count = 0;
            foreach (var word in words)
            {
                if (word.Length > 2) count++;
            }
            return count;
        }

        public static string ToSpinalCase(string str)
        {
            string[] words = str.ToLower().Split(' ');
            return string.Join("-", words);
        }

        public static string ToPascalCase(this string str)
        {
            string[] words = str.Split(' ');
            StringBuilder result = new StringBuilder();

            foreach (var word in words) 
            {
                result.Append(char.ToUpper(word[0]));
                result.Append(word.Substring(1).ToLower());
            }
            return result.ToString();
        }
    }
}
