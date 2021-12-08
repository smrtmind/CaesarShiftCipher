using System;

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

            while (exitTheProgram != "y")
            {
                int complexity = 0;
                //random code to generate some kind of unic key
                const decimal code = 091619888717;
                string input = string.Empty;
                string cipher = string.Empty;

                Console.Clear();
                Print.Text("[1] ENCRYPTOR\t", ConsoleColor.DarkMagenta);
                Print.Text("[2] DECRYPTOR\t__________\n", ConsoleColor.DarkBlue);

                int encryptOrDecrypt = 0;
                while (encryptOrDecrypt != 1 && encryptOrDecrypt != 2)
                {
                    Print.Text("| ".PadLeft(33, ' '), ConsoleColor.DarkBlue);
                    Print.Text("select: ");
                    int.TryParse(Console.ReadLine(), out encryptOrDecrypt);
                }
                Console.WriteLine();

                //if you want to encrypt
                if (encryptOrDecrypt == 1)
                {
                    while (input.Length == 0)
                    {
                        Print.Text($"Enter the original text:\n", ConsoleColor.DarkMagenta);
                        input = Console.ReadLine();
                    }

                    complexity = random.Next(1, Source.GetSymbolsLength());
                    Print.Text($"\nEncrypted\n", ConsoleColor.DarkMagenta);
                    Print.Text($"{Encoder.Use(complexity, input)}\n\n");
                    Print.Text($"KEY:\n", ConsoleColor.DarkMagenta);
                    //generating key, to decode your message
                    Source.GetIndexes();
                    Print.Text($"{complexity * code}\n\n");
                    
                }

                //else decrypt
                else
                {
                    while (input.Length == 0)
                    {
                        Print.Text($"Enter the encrypted text:\n", ConsoleColor.DarkBlue);
                        input = Console.ReadLine();
                    }

                    while (cipher.Length == 0)
                    {
                        Print.Text($"\nKEY: ", ConsoleColor.DarkBlue);
                        cipher = Console.ReadLine();
                    }
                    
                    Print.Text($"\nDecrypted\n", ConsoleColor.DarkBlue);
                    Print.Text($"{Decoder.Use(cipher, code, input)}\n\n");
                }

                exitTheProgram = string.Empty;
                while (exitTheProgram != "n" && exitTheProgram != "y")
                {
                    Print.Text("Exit the program? [y] / [n]: ", ConsoleColor.DarkGray);
                    exitTheProgram = Console.ReadLine().ToLower();
                }
            }
        }
    }
}
