using System;
using System.Collections.Generic;

namespace CaesarShiftCipher
{
    class Program
    {
        static Random random = new Random();
        static List<char> symbols = GetSymbolsArray();
        static int symbolsLength = symbols.Count;
        static List<char> randomSymbols = GetRandomArray();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string exitTheProgram = string.Empty;

            while (exitTheProgram.ToLower() != "y")
            {
                decimal complexity = 0;
                //random code to generate some kind of unic key
                const decimal code = 098816871917;
                string input = string.Empty;

                Console.Clear();
                Print("[1] ENCRYPTOR\t", ConsoleColor.DarkMagenta);
                Print("[2] DECRYPTOR\t__________\n", ConsoleColor.DarkBlue);

                int encryptOrDecrypt = 0;
                while (encryptOrDecrypt != 1 && encryptOrDecrypt != 2)
                {
                    Print("| ".PadLeft(33, ' '), ConsoleColor.DarkBlue);
                    Print("select: ");
                    int.TryParse(Console.ReadLine(), out encryptOrDecrypt);
                }
                Console.WriteLine();

                //if you want to encrypt
                if (encryptOrDecrypt == 1)
                {
                    while (input.Length == 0)
                    {
                        Print($"Enter the original text:\n", ConsoleColor.DarkMagenta);
                        input = Console.ReadLine();
                    }

                    complexity = random.Next(1, symbolsLength);
                    Print($"\nKEY: ", ConsoleColor.DarkMagenta);
                    //generating key, to decode your message
                    Print($"{complexity * code}\n");
                    Print($"\nEncrypted\n", ConsoleColor.DarkMagenta);
                    Print($"{Algorithm(complexity, input, encode: true)}\n\n");
                }

                //else decrypt
                else
                {
                    while (input.Length == 0)
                    {
                        Print($"Enter the encrypted text:\n", ConsoleColor.DarkBlue);
                        input = Console.ReadLine();
                    }

                    Console.WriteLine();
                    while (complexity > symbolsLength || complexity == 0)
                    {
                        Print($"KEY: ", ConsoleColor.DarkBlue);
                        decimal.TryParse(Console.ReadLine(), out complexity);
                        complexity /= code;

                        if (complexity <= symbolsLength && complexity != 0) break;
                    }

                    Print($"\nDecrypted\n", ConsoleColor.DarkBlue);
                    Print($"{Algorithm(complexity, input)}\n\n");
                }

                exitTheProgram = string.Empty;
                while (exitTheProgram.ToLower() != "n" && exitTheProgram.ToLower() != "y")
                {
                    Print("Exit the program? [y] / [n]: ", ConsoleColor.DarkGray);
                    exitTheProgram = Console.ReadLine();
                }
            }
        }
        static string Algorithm(decimal complexity, string input, bool encode = false)
        {
            char[] userInput = input.ToCharArray();
            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < symbolsLength; j++)
                {
                    if (userInput[i] == symbols[j])
                    {
                        //encoding
                        if (encode) index = j + (int)complexity;
                        //decoding
                        else index = j + (symbolsLength - (int)complexity);
                    }
                }

                if (index >= symbolsLength)
                {
                    index -= symbolsLength;
                    userInput[i] = symbols[index];
                }

                else userInput[i] = symbols[index];
            }

            return new string(userInput);
        }

        public static List<char> GetSymbolsArray()
        {
            List<char> symbols = new List<char>{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
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
                               '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            return symbols;
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static List<char> GetRandomArray()
        {
            Random random = new Random();

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
                    Source.indexes.Add(index);
                }
            }

            return randomSymbols;
        }
    }
}
