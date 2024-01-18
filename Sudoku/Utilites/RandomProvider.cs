using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Utilites
{
    static class RandomProvider
    {
        private static Random _random = new Random();

        public static int RandomNext(int left, int right)
        {
            return _random.Next(left, right + 1);
        }
    }
}
