﻿using System;
using System.IO;
using System.Threading;

namespace CaesarShiftCipher
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string exitTheProgram = string.Empty;

            while (exitTheProgram.ToLower() != "y")
            {
                decimal code = 098816871917;
                decimal complexity = 0;
                string input = string.Empty;
                string output = string.Empty;
                string result = string.Empty;

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

                if (encryptOrDecrypt == 1)
                {
                    while (input.Length == 0)
                    {
                        Print($"Enter the original text:\n", ConsoleColor.DarkMagenta);
                        input = Console.ReadLine();
                    }
                    char[] userInput = input.ToCharArray();

                    complexity = random.Next(1, 160);
                    Print($"\nComplexity: {complexity * code}", ConsoleColor.DarkBlue);
                    result = Algorithm(complexity, userInput, encode: true);
                    output = "Encrypted";
                }

                if (encryptOrDecrypt == 2)
                {
                    while (input.Length == 0)
                    {
                        Print($"Enter the encrypted text:\n", ConsoleColor.DarkMagenta);
                        input = Console.ReadLine();
                    }
                    char[] userInput = input.ToCharArray();

                    Console.WriteLine();
                    while (complexity > 160 || complexity == 0)
                    {
                        Print($"Complexity: ", ConsoleColor.DarkBlue);
                        decimal.TryParse(Console.ReadLine(), out complexity);
                        complexity /= code;

                        if (complexity <= 160 && complexity != 0) break;
                    }
                    result = Algorithm(complexity, userInput, decode: true);
                    output = "Decrypted";
                }           

                Print($"\n{output}\n", ConsoleColor.DarkMagenta);
                Print($"{result}\n\n");

                exitTheProgram = string.Empty;
                while (exitTheProgram.ToLower() != "n" && exitTheProgram.ToLower() != "y")
                {
                    Print("Exit the program? [y] / [n]: ", ConsoleColor.DarkGray);
                    exitTheProgram = Console.ReadLine();
                }
            }
        }
        static string Algorithm(decimal complexity, char[] userInput, bool encode = false, bool decode = false)
        {
            char[] symbols = GetAlphabet();

            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (encode)
                    {
                        if (userInput[i] == symbols[j])
                            index = j + (int)complexity;
                    }

                    if (decode)
                    {
                        if (userInput[i] == symbols[j])
                            index = j + (symbols.Length - (int)complexity);
                    }
                }

                if (index >= symbols.Length)
                {
                    index -= symbols.Length;
                    userInput[i] = symbols[index];
                }

                else userInput[i] = symbols[index];
            }

            return new string(userInput);
        }

        public static char[] GetAlphabet()
        {
            char[] symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
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
    }
}
