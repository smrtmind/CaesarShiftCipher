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
                //mixes alphabet
                'o', 'n', 'q', 'p', 's', 'r', 'u', 't', 'w', 'v', 'y', 'x', 'z',
                'b', 'a', 'd', 'c', 'f', 'e', 'h', 'g', 'j', 'i', 'l', 'k', 'm',
                'O', 'N', 'Q', 'P', 'S', 'R', 'U', 'T', 'W', 'V', 'Y', 'X', 'Z',
                'B', 'A', 'D', 'C', 'F', 'E', 'H', 'G', 'J', 'I', 'L', 'K', 'M',
                'н', 'м', 'п', 'о', 'с', 'р', 'у', 'т', 'х', 'ф', 'ч', 'ц', 'ш',
                'б', 'а', 'г', 'в', 'е', 'д', 'ж', 'ё', 'и', 'з', 'к', 'й', 'л',
                'Ж', 'Ё', 'И', 'З', 'К', 'Й', 'М', 'Л', 'О', 'Н', 'Р', 'П', 'С',
                'ъ', 'щ', 'ь', 'ы', 'ю', 'э', 'А', 'я', 'В', 'Б', 'Д', 'Г', 'Е',
                'Ъ', 'Щ', 'Ь', 'Ы', 'Ю', 'Э', 'Т', 'Я', 'Ф', 'У', 'Ц', 'Х', 'Ч', 
                'Ш',
                '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=',
                '+', '?', '<', '>', ':', ';', '.', ',', '|', '/', '~', '{', '}',
                '[', ']', '№', ' ', '\'', '\"','\\',
                '1', '0', '3', '2', '5', '4', '7', '6', '9', '8' 
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
