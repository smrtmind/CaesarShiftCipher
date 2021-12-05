using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarShiftCipher
{
    public class Encoder
    {
        public static string Use(int complexity, string input)
        {
            char[] userInput = input.ToCharArray();
            List<char> randomSymbols = Source.GetRandomArray();
            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < Source.GetSymbolsLength(); j++)
                {
                    if (userInput[i] == randomSymbols[j])
                        index = j + complexity;
                }

                if (index >= Source.GetSymbolsLength())
                {
                    index -= Source.GetSymbolsLength();
                    userInput[i] = randomSymbols[index];
                }

                else userInput[i] = randomSymbols[index];
            }

            return new string(userInput);
        }
    }
}
