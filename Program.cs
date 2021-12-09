using System;
using System.IO;

namespace CaesarShiftCipher
{
    class Program
    {
        static Random random = new Random();
        private static string encryptedText = string.Empty;
        private static string encryptedCipher = string.Empty;
        private static string decryptedText = string.Empty;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string exitTheProgram = string.Empty;

            while (exitTheProgram != "y")
            {
                string input = string.Empty;
                string cipher = string.Empty;

                int encryptOrDecrypt = 0;
                while (encryptOrDecrypt != 1 && encryptOrDecrypt != 2)
                {
                    Console.Clear();
                    Print.Text("[1] ENCRYPTOR\t", ConsoleColor.DarkMagenta);
                    Print.Text("[2] DECRYPTOR\t__________\n", ConsoleColor.DarkBlue);
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
                            File.WriteAllText(@"C:\Users\[name_of_the_user]\Desktop\encrypted.txt", $"Text:\n{encryptedText}\n\nKEY:\n{encryptedCipher}");
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
