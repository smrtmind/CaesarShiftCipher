using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarShiftCipher
{
    public class RandomArrayIndexes
    {
        public int[] Indexes { get; set; }

        public RandomArrayIndexes() { }

        public RandomArrayIndexes(int[] indexes) => Indexes = indexes;
    }
}
