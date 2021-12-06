using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    public class Day6
    {
        public static int FirstStar(IEnumerable<string> input)
        {
            var fish = input.First().Split(",").Select(s => int.Parse(s))
                .Select(a => new LanternFish(a))
                .ToList();

            foreach(var day in Enumerable.Range(1, 80))
            {
                fish = fish.SelectMany(f => f.Spawn()).Concat(fish).Select(f => f.Day()).ToList();
            }

            return fish.Count();
        }

        public static Int64 SecondStar(IEnumerable<string> input)
        {
            var fish = input.First().Split(",").Select(s => int.Parse(s))
                .GroupBy(i => i)
                .Select(g => new LanternFish(g.Key, g.Count()))
                .ToList();

            foreach(var day in Enumerable.Range(1, 256))
            {
                fish = fish.SelectMany(f => f.Spawn())
                    .Concat(fish)
                    .GroupBy(f => f.Cycle)
                    .Select(g => new LanternFish(g.Key, g.Sum(f => f.Quantity)))
                    .Select(f => f.Day()).ToList();
            }

            return fish.Sum(f => f.Quantity);
        }

        private class LanternFish
        {
            public int Cycle {get; private set;}

            public Int64 Quantity { get; } = 1;

            public LanternFish(int cycle, Int64 quantity = 1)
            {
                Cycle = cycle;
                Quantity = quantity;
            }

            public LanternFish Day()
            {
                Cycle = Cycle == 0 ? 6 : Cycle -1;

                return this;
            }

            public IEnumerable<LanternFish> Spawn()
            {
                if(Cycle == 0)
                    return new []{new LanternFish(9, Quantity)};

                return Enumerable.Empty<LanternFish>();
            }
        }
    }
}