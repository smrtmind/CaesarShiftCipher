using System;
using System.Collections.Generic;

namespace CaesarShiftCipher
{
    public class Decoder
    {
        private static int symbolsLength = Source.GetSymbolsLength();

        public static string Use(string cipher, decimal code, string input)
        {
            char[] userInput = input.ToCharArray();
            string[] cipherArray = cipher.Split('|');

            if (cipherArray.Length != symbolsLength + 1)
                return "incorrect format of entered key";

            int[] indexes = new int[cipherArray.Length - 1];

            for (int i = 0; i < indexes.Length; i++)
                indexes[i] = Convert.ToInt32(cipherArray[i]);

            decimal complexity = Convert.ToDecimal(cipherArray[cipherArray.Length - 1]) / code; 

            List<char> randomSymbols = Source.GetOriginalArray(indexes);

            int index = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < symbolsLength; j++)
                {
                    if (userInput[i] == randomSymbols[j])
                        index = j + (symbolsLength - (int)complexity);
                }

                if (index >= symbolsLength)
                {
                    index -= symbolsLength;
                    userInput[i] = randomSymbols[index];
                }

                else userInput[i] = randomSymbols[index];
            }

            return new string(userInput);
        }
    }
}
