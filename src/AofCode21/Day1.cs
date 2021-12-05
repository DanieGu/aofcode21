using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    public class Day1
    {
        public static int FirstStar(IEnumerable<string> inputStr)
        {
            var input = inputStr.Select(s => int.Parse(s)).ToArray();
            var increases = input.Select((val,index) => new {val, prev = input[Math.Max(0, index -1)] })
                .Where(x => x.val > x.prev)
                .Count();

            return increases;
        }

        public static int SecondStar(IEnumerable<string> inputStr)
        {
            var input = inputStr.Select(s => int.Parse(s)).ToArray();
            var increases = input
                .Where((val, index) => index + 3 <= input.Length)
                .Select((val,index) => new {val = SumWindow(input, index), prev = SumWindow(input, Math.Max(0, index -1)) })
                .Where(x => x.val > x.prev)
                .Count();

            return increases;
        }

        private static int SumWindow(int[] input, int index)
        {
            return input[index] + input[index + 1] + input[index + 2];
        }
    }

}