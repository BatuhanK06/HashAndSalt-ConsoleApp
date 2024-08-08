using System;
using System.Linq;
using HashAndSaltConsoleApp.src.Data;

namespace HashAndSaltConsoleApp.src.IsValid
{
    internal class IsValid
    {
        public static bool IsValidForEncryption(string input)
        {
            foreach (var ch in input.ToUpper())
            {
                if (!MappingData.charToHexMap.ContainsKey(ch) && !char.IsWhiteSpace(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidForDecryption(string input)
        {
            if (input.Length % 4 != 0) //dizideki karakter sayısı ile bölünüp bölünülmediğini kontrol eder.
            {
                return false;
            }

            var hexParts = SplitIntoChunks(input, 4);
            foreach (var hex in hexParts)
            {
                if (!MappingData.hexToCharMap.ContainsKey(hex))
                {
                    return false;
                }
            }
            return true;
        }

        private static IEnumerable<string> SplitIntoChunks(string input, int chunkSize)
        {
            for (int i = 0; i < input.Length; i += chunkSize)
            {
                yield return input.Substring(i, Math.Min(chunkSize, input.Length - i));
            }
        }
    }
}
