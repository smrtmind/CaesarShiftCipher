using System;

namespace CaesarShiftCipher
{
    public class Print
    {
        public static void Text(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void Cipher(string complexity)
        {
            foreach (var combination in Source.GenerateMask())
                Console.Write(combination + "~");

            Text($"{complexity}\n\n");
        }
    }
}
