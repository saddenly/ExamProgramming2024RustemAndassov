using System;
using Utilities;

namespace UtilitiesTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = "Marcin Jagiela";
            Console.WriteLine($"LongWordsCount('{text1}'): {StringUtilities.LongWordsCount(text1)}");

            string text2 = "The lord of the rings";
            Console.WriteLine($"LongWordsCount('{text2}'): {StringUtilities.LongWordsCount(text2)}");

            string text3 = "Marcin Jagiela";
            Console.WriteLine($"ToSpinalCase('{text3}'): {StringUtilities.ToSpinalCase(text3)}");

            string text4 = "the LorD OF thE Rings";
            Console.WriteLine($"ToSpinalCase('{text4}'): {StringUtilities.ToSpinalCase(text4)}");

            string text5 = "marcin jagiela";
            Console.WriteLine($"ToPascalCase('{text5}'): {text5.ToPascalCase()}");

            string text6 = "the LorD OF thE Rings";
            Console.WriteLine($"ToPascalCase('{text6}'): {text6.ToPascalCase()}");
            Console.ReadKey();
        }
    }
}
