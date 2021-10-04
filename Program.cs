using System;
using System.IO;
using System.Threading;

namespace CaesarShiftCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string exitTheProgram = string.Empty;
            int encryptOrDecrypt = 0;
            int complexity = 0;

            while (exitTheProgram.ToLower() != "y")
            {
                string[] text = new string[3];

                Console.Clear();
                Print("[1] ENCRYPTOR\t", ConsoleColor.DarkMagenta);
                Print("[2] DECRYPTOR\t__________\n", ConsoleColor.DarkBlue);

                encryptOrDecrypt = 0;
                while (encryptOrDecrypt != 1 && encryptOrDecrypt != 2)
                {
                    Print("| ".PadLeft(33, ' '), ConsoleColor.DarkBlue);
                    Print("select: ");
                    int.TryParse(Console.ReadLine(), out encryptOrDecrypt);
                }
                Console.WriteLine();

                if (encryptOrDecrypt == 1)
                {
                    text[0] = "Enter the original text:";
                    text[1] = "Level of encryption (1-25):";
                    text[2] = $"Encrypted:";
                }

                if (encryptOrDecrypt == 2)
                {
                    text[0] = "Enter the encrypted text:";
                    text[1] = "Level of decryption (1-25):";
                    text[2] = "Decrypted:";
                }

                string input = string.Empty;
                while (input.Length == 0)
                {
                    Print($"{text[0]} \n", ConsoleColor.DarkMagenta);
                    input = Console.ReadLine();
                }
                
                char[] userInput = input.ToLower().ToCharArray();

                complexity = 0;
                while (complexity > 25 || complexity == 0)
                {
                    Print($"\n{text[1]} ", ConsoleColor.DarkBlue);
                    int.TryParse(Console.ReadLine(), out complexity);

                    if (complexity <= 25 && complexity != 0) break;
                }

                if (encryptOrDecrypt == 1)
                    Algorithm(complexity, userInput, enc: true);
                if (encryptOrDecrypt == 2)
                    Algorithm(complexity, userInput, dec: true);

                Print($"\n{text[2]}\n", ConsoleColor.DarkMagenta);

                foreach (var letter in userInput)
                    Console.Write(letter);
                Console.WriteLine();

                exitTheProgram = string.Empty;
                while (exitTheProgram.ToLower() != "n" && exitTheProgram.ToLower() != "y")
                {
                    Console.Write("\n\nExit the program? [y] / [n]: ");
                    exitTheProgram = Console.ReadLine();
                }
            }
        }
        static void Algorithm(int complexity, char[] userInput, bool enc = false, bool dec = false)
        {
            char[] symbols = GetAlphabet();

            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (enc)
                    {
                        if (userInput[i] == symbols[j])
                            index = j + complexity;
                    }

                    if (dec)
                    {
                        if (userInput[i] == symbols[j])
                            index = j + (symbols.Length - complexity);
                    }
                }

                if (index >= symbols.Length)
                {
                    index -= symbols.Length;
                    userInput[i] = symbols[index];
                }

                else userInput[i] = symbols[index];
            }
        }

        public static char[] GetAlphabet()
        {
            char[] symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 
                                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 
                                'ъ', 'ы', 'ь', 'э', 'ю', 'я', 
                                '.', ',', '?', '-', '/', '_', '!', ' ', '~', '+', '*', '=', '&', 
                                '%', '#', '№', '@', ';', ':', '>', '<', '\'', '\"', '\\',
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
