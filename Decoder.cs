using System;
using System.Collections.Generic;

namespace CaesarShiftCipher
{
    public class Decoder
    {
        public static string Use(string cipher, decimal code, string input)
        {
            char[] userInput = input.ToCharArray();
            string[] cipherArray = cipher.Split('|');

            if (cipherArray.Length != Source.GetSymbolsLength() + 1)
                return "incorrect format of entered key";

            int[] indexes = new int[cipherArray.Length - 1];

            for (int i = 0; i < indexes.Length; i++)
                indexes[i] = Convert.ToInt32(cipherArray[i]);

            decimal complexity = Convert.ToDecimal(cipherArray[cipherArray.Length - 1]) / code; 

            List<char> randomSymbols = Source.GetOriginalArray(indexes);

            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < Source.GetSymbolsLength(); j++)
                {
                    if (userInput[i] == randomSymbols[j])
                        index = j + (Source.GetSymbolsLength() - (int)complexity);
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
