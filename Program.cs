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

            char[] englishUpper = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] englishLower = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            int ENlength = englishLower.Length;

            char[] russianUpper = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
            char[] russianLower = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            int RUlength = russianLower.Length;

            int encryptOrDecrypt = 0, enOrRu = 0, level = 0;
            string yesOrNo = string.Empty;

            while (yesOrNo != "n".ToLower())
            {
                Console.Write("What do you want to do?");
                Console.WriteLine("[1] encrypt".PadLeft(15, ' '));
                Console.WriteLine("[2] decrypt\n".PadLeft(39, ' '));

                do
                {
                    Console.Write("input: ".PadLeft(34, ' '));
                    int.TryParse(Console.ReadLine(), out encryptOrDecrypt);

                    if (encryptOrDecrypt == 1 || encryptOrDecrypt == 2) break;
                    else Console.WriteLine("incorrect".PadLeft(43));
                }
                while (encryptOrDecrypt != 1 || encryptOrDecrypt != 2);

                Console.Write("\nChoose the language:");
                Console.WriteLine("[1] english".PadLeft(18, ' '));
                Console.WriteLine("[2] russian\n".PadLeft(39, ' '));

                do
                {
                    Console.Write("input: ".PadLeft(34, ' '));
                    int.TryParse(Console.ReadLine(), out enOrRu);

                    if (enOrRu == 1 || enOrRu == 2) break;
                    else Console.WriteLine("incorrect".PadLeft(43));
                }
                while (enOrRu != 1 || enOrRu != 2);

                if (encryptOrDecrypt == 1)
                {
                    Console.WriteLine("\nEnter the original text: ");
                    string input = Console.ReadLine();
                    char[] letters = input.ToCharArray();

                    do
                    {
                        Console.Write($"{Environment.NewLine}Enter the level of encryption (1-25): ");
                        int.TryParse(Console.ReadLine(), out level);

                        if (level <= 25 && level != 0) break;
                        else Console.Write("incorrect".PadLeft(47));
                    }
                    while (level > 25 || level == 0);

                    if (enOrRu == 1)
                    {
                        Encryptor(level, ENlength, letters, englishUpper, englishLower);

                        GetLoading("".PadLeft(115, '|'));
                        Console.WriteLine();

                        Console.WriteLine($"{Environment.NewLine}Result (encryption level {level}):");

                        foreach (var letter in letters)
                        {
                            Console.Write(letter);
                        }

                        Console.WriteLine();
                    }

                    if (enOrRu == 2)
                    {
                        Encryptor(level, RUlength, letters, russianUpper, russianLower);

                        GetLoading("".PadLeft(115, '|'));
                        Console.WriteLine();

                        Console.WriteLine($"{Environment.NewLine}Result (encryption level {level}):");

                        foreach (var letter in letters)
                        {
                            Console.Write(letter);
                        }

                        Console.WriteLine();
                    }
                }

                if (encryptOrDecrypt == 2)
                {
                    Console.WriteLine("\nEnter the encrypted text: ");
                    string input = Console.ReadLine();
                    char[] letters = input.ToCharArray();

                    do
                    {
                        Console.Write($"{Environment.NewLine}Enter the level of decryption (1-25): ");
                        int.TryParse(Console.ReadLine(), out level);

                        if (level <= 25 && level != 0) break;
                        else Console.Write("incorrect".PadLeft(47));
                    }
                    while (level > 25 || level == 0);

                    if (enOrRu == 1)
                    {
                        Decryptor(level, ENlength, letters, englishUpper, englishLower);

                        GetLoading("".PadLeft(115, '|'));
                        Console.WriteLine();

                        Console.WriteLine($"{Environment.NewLine}Result of decryption:");

                        foreach (var letter in letters)
                        {
                            Console.Write(letter);
                        }

                        Console.WriteLine();
                    }

                    if (enOrRu == 2)
                    {
                        Decryptor(level, RUlength, letters, russianUpper, russianLower);

                        GetLoading("".PadLeft(115, '|'));
                        Console.WriteLine();

                        Console.WriteLine($"{Environment.NewLine}Result of decryption:");

                        foreach (var letter in letters)
                        {
                            Console.Write(letter);
                        }

                        Console.WriteLine();
                    }
                }

                do
                {
                    Console.Write("\nDo you want to continue using the program? [y] / [n]: ");
                    yesOrNo = Console.ReadLine();

                    if (yesOrNo.ToLower() == "y")
                    {
                        Console.Clear();
                        break;
                    }

                    if (yesOrNo.ToLower() == "n") break;

                    else Console.Write("incorrect".PadLeft(63));
                }
                while (yesOrNo.ToLower() != "n" || yesOrNo.ToLower() != "y");
            }
        }
        static void Encryptor(int level, int alphabetLength, char[] letters, char[] letterUpper, char[] lettersLower)
        {
            char[] symbols = { '.', ',', '?', '-', '/', '\\', '_', '!', ' ', '+', '*', '=', '&', '%', '#', '№', '@', ';', ':', '>', '<', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            int index = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                for (int k = 0; k < alphabetLength; k++)
                {
                    if (letters[i] == letterUpper[k] || letters[i] == lettersLower[k])
                        index = k + level;
                }

                if (index >= alphabetLength)
                {
                    index -= alphabetLength;
                    letters[i] = lettersLower[index];
                }

                else if (letters[i] == ' ') letters[i] = ' ';
                else if (letters[i] == '.') letters[i] = '.';
                else if (letters[i] == ',') letters[i] = ',';
                else if (letters[i] == '?') letters[i] = '?';
                else if (letters[i] == '!') letters[i] = '!';
                else if (letters[i] == '-') letters[i] = '-';
                else if (letters[i] == '\'') letters[i] = '\'';
                else if (letters[i] == '\"') letters[i] = '\"';
                else if (letters[i] == '1') letters[i] = '1';
                else if (letters[i] == '2') letters[i] = '2';
                else if (letters[i] == '3') letters[i] = '3';
                else if (letters[i] == '4') letters[i] = '4';
                else if (letters[i] == '5') letters[i] = '5';
                else if (letters[i] == '6') letters[i] = '6';
                else if (letters[i] == '7') letters[i] = '7';
                else if (letters[i] == '8') letters[i] = '8';
                else if (letters[i] == '9') letters[i] = '9';
                else if (letters[i] == '0') letters[i] = '0';

                else letters[i] = lettersLower[index];
            }
        }
        static void Decryptor(int level, int alphabetLength, char[] letters, char[] letterUpper, char[] lettersLower)
        {
            int index = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                for (int k = 0; k < alphabetLength; k++)
                {
                    if (letters[i] == letterUpper[k] || letters[i] == lettersLower[k])
                        index = k + (alphabetLength - level);
                }

                if (index >= alphabetLength)
                {
                    index -= alphabetLength;
                    letters[i] = lettersLower[index];
                }

                else if (letters[i] == ' ') letters[i] = ' ';
                else if (letters[i] == '.') letters[i] = '.';
                else if (letters[i] == ',') letters[i] = ',';
                else if (letters[i] == '?') letters[i] = '?';
                else if (letters[i] == '!') letters[i] = '!';
                else if (letters[i] == '-') letters[i] = '-';
                else if (letters[i] == '\'') letters[i] = '\'';
                else if (letters[i] == '\"') letters[i] = '\"';
                else if (letters[i] == '1') letters[i] = '1';
                else if (letters[i] == '2') letters[i] = '2';
                else if (letters[i] == '3') letters[i] = '3';
                else if (letters[i] == '4') letters[i] = '4';
                else if (letters[i] == '5') letters[i] = '5';
                else if (letters[i] == '6') letters[i] = '6';
                else if (letters[i] == '7') letters[i] = '7';
                else if (letters[i] == '8') letters[i] = '8';
                else if (letters[i] == '9') letters[i] = '9';
                else if (letters[i] == '0') letters[i] = '0';

                else letters[i] = lettersLower[index];
            }
        }
        static string GetLoading(string randomPhrase)
        {
            char[] letters = randomPhrase.ToCharArray();

            foreach (char arr in letters)
            {
                Console.Write(arr);
                Thread.Sleep(5);
            }

            return randomPhrase;
        }
    }
}
