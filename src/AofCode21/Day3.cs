using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    //https://adventofcode.com/2021/day/3
    public class Day3
    {
        public static int FirstStar(IEnumerable<string> input)
        {
            var bits = input.Select(s => s.Select(c => c == '1' ? true : false).ToArray()).ToList();

            var gamma = bits.First()
                .Select((value,index) => bits.Select(b => b[index]).ToArray())
                .Select(b => b.GroupBy(g => g).OrderByDescending(g => g.Count()).First().Key);

            var epsilon = gamma.Select(b => !b);

            return BitsToInt(gamma) * BitsToInt(epsilon);
        }

        private static int BitsToInt(IEnumerable<bool> bits)
        {
            return Convert.ToInt32(new string(bits.Select(b => b ? '1' : '0').ToArray()), 2);
        }

        public static int SecondStar(IEnumerable<string> input)
        {
            var bits = input.Select(s => s.Select(c => c == '1' ? true : false).ToArray()).ToList();

            var oRating = Filter(bits, 0, positive:true).Single();
            var co2Rating = Filter(bits, 0, positive:false).Single();

            return BitsToInt(oRating) * BitsToInt(co2Rating);
        }

        private static IEnumerable<bool[]> Filter(IEnumerable<bool[]> bits, int index, bool positive)
        {
            bits = bits.GroupBy(bs => bs[index]).OrderBy(g => g.Count()).ThenBy(g => g.Key).Skip(Convert.ToInt32(positive)).First();
            if(bits.Count() > 1)
                return Filter(bits, index + 1, positive);
            
            return bits;
        }        
    }
}
