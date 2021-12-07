using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    //https://adventofcode.com/2021/day/7
    public class Day7
    {
        public static Int64 FirstStar(IEnumerable<string> input)
        {
            var crabs = input.First().Split(",").Select(s => int.Parse(s));
            
            var fuel = Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min() + 1).Min(p => crabs.Sum(c => Math.Abs(p - c)));
            return fuel;
        }

        public static Int64 SecondStar(IEnumerable<string> input)
        {
            var crabs = input.First().Split(",").Select(s => int.Parse(s));
            
            var fuel = Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min() + 1)
                .Min(p => crabs.Sum(c => Enumerable.Range(1, Math.Abs(p - c)).Sum()));
            return fuel;
        }
    }
}