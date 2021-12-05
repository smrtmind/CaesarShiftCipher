using System;
using System.Collections.Generic;

namespace CaesarShiftCipher
{
    class Program
    {
        static Random random = new Random();
        static int symbolsLength = Source.GetSymbolsLength();

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
                    Print($"\nEncrypted\n", ConsoleColor.DarkMagenta);
                    Print($"{Algorithm(complexity, input, encode: true)}\n\n");
                    Print($"KEY: ", ConsoleColor.DarkMagenta);
                    //generating key, to decode your message
                    Print($"{complexity * code} / {Source.GetIndexes()}\n\n");
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
            List<char> symbols = Source.GetRandomArray();
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

        public static void Print(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
