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
                int complexity = 0;
                //random code to generate some kind of unic key
                const decimal code = 091619888717;
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
                    Print($"{Encoder.Use(complexity, input)}\n\n");
                    Print($"KEY: ", ConsoleColor.DarkMagenta);
                    //generating key, to decode your message
                    //Source.GetCipher(complexity);
                    Print($"{Source.GetIndexes()} {complexity * code}\n\n");
                }

                //else decrypt
                else
                {
                    string cipher = string.Empty;

                    while (input.Length == 0)
                    {
                        Print($"Enter the encrypted text:\n", ConsoleColor.DarkBlue);
                        input = Console.ReadLine();
                    }

                    Console.WriteLine();

                        Print($"KEY: ", ConsoleColor.DarkBlue);
                        cipher = Console.ReadLine();


                        //decimal.TryParse(Console.ReadLine(), out complexity);
                        //complexity /= code;



                    Print($"\nDecrypted\n", ConsoleColor.DarkBlue);
                    Print($"{Decoder.Use(cipher, code, input)}\n\n");
                }

                exitTheProgram = string.Empty;
                while (exitTheProgram.ToLower() != "n" && exitTheProgram.ToLower() != "y")
                {
                    Print("Exit the program? [y] / [n]: ", ConsoleColor.DarkGray);
                    exitTheProgram = Console.ReadLine();
                }
            }
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
