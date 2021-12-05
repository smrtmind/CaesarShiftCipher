using System;
using System.Collections.Generic;
using System.Linq;

namespace CaesarShiftCipher
{
    public class Source
    {
        private static Random random = new Random();
        public static List<int> indexes;

        public static List<char> GetSymbolsArray()
        {
            List<char> symbols = new List<char>
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
                'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш',
                'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л',
                'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш',
                'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
                '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=',
                '+', '?', '<', '>', ':', ';', '.', ',', '|', '/', '~', '{', '}',
                '[', ']', '№', ' ', '\'', '\"','\\',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            return symbols;
        }

        public static int GetSymbolsLength() => GetSymbolsArray().Count;

        public static List<char> GetRandomArray()
        {
            indexes = new List<int>();
            List<char> symbols = GetSymbolsArray();
            List<char> randomSymbols = new List<char>();

            int defaultCounter = default;

            while (defaultCounter != symbols.Count)
            {
                int index = random.Next(0, symbols.Count);

                if (symbols[index] != default)
                {
                    randomSymbols.Add(symbols[index]);
                    symbols[index] = default;

                    defaultCounter++;
                    indexes.Add(index);
                }
            }

            return randomSymbols;
        }

        public static string GetIndexes() => String.Join("|", indexes.Select(p => p.ToString()).ToArray());

        public static List<char> GetOriginalArray(int[] indexes)
        {
            List<char> symbols = GetSymbolsArray();
            List<char> randomSymbols = new List<char>();

            for (int i = 0; i < indexes.Length; i++)
                randomSymbols.Add(symbols[indexes[i]]);

            return randomSymbols;
        }
    }
}
