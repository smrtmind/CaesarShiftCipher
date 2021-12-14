using System;
using System.IO;

namespace CaesarShiftCipher
{
    class Program
    {
        private static Random random = new Random();
        private static string encryptedCipher = string.Empty;
        private static string encryptedText = string.Empty;
        private static string decryptedText = string.Empty;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string exitTheProgram = string.Empty;

            while (exitTheProgram != "y")
            {
                Source.InitializeResources();

                string input = string.Empty;
                string cipher = string.Empty;

                int encryptOrDecrypt = default;
                while (encryptOrDecrypt != 1 && encryptOrDecrypt != 2)
                {
                    Console.Clear();
                    Print.Text("[1] ENCRYPTOR\t", ConsoleColor.DarkMagenta);
                    Print.Text("[2] DECRYPTOR\t__________\n", ConsoleColor.DarkBlue);
                    Print.Text("| ".PadLeft(33, ' '), ConsoleColor.DarkBlue);
                    Print.Text("select: ");
                    int.TryParse(Console.ReadLine(), out encryptOrDecrypt);
                }
                Print.Text("\n");

                //if you want to encrypt
                if (encryptOrDecrypt == 1)
                {
                    while (input.Length == 0)
                    {
                        Print.Text($"Enter the original text:\n", ConsoleColor.DarkMagenta);
                        input = Console.ReadLine();
                    }

                    //generating key, to encode your message
                    int key = random.Next(1, Source.GetSymbolsLength());
                    encryptedText = Encoder.Use(key, input);
                    encryptedCipher = Source.GetCipher();

                    Print.Text($"\nEncrypted\n", ConsoleColor.DarkMagenta);
                    Print.Text($"{encryptedText}\n\n");
                    Print.Text($"KEY:\n", ConsoleColor.DarkMagenta);
                    Print.Text($"{encryptedCipher}\n\n");

                    do
                    {
                        Print.Text("Save result to file? [y] / [n]: ", ConsoleColor.DarkGray);
                        input = Console.ReadLine().ToLower();

                        if (input == "y")
                        {
                            Print.Text($"file with result was created on your desktop\n", ConsoleColor.DarkGreen);
                            File.WriteAllText(@"C:\Users\[user's name]\Desktop\encrypted.txt", 
                                              $"Text:\n{encryptedText}\n\n" +
                                              $"KEY:\n{encryptedCipher}");
                        }
                    }
                    while (input != "y" && input != "n");
                    Print.Text("\n");
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
                        Print.Text($"\nKEY:\n", ConsoleColor.DarkBlue);
                        cipher = Console.ReadLine();
                    }

                    decryptedText = Decoder.Use(cipher, input);

                    Print.Text($"\nDecrypted\n", ConsoleColor.DarkBlue);
                    Print.Text($"{decryptedText}\n\n");
                }

                do
                {
                    Print.Text("Exit the program? [y] / [n]: ", ConsoleColor.DarkGray);
                    exitTheProgram = Console.ReadLine().ToLower();
                }
                while (exitTheProgram != "n" && exitTheProgram != "y");
            }
        }
    }
}