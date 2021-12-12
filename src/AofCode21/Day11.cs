namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/11
public class Day11
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var octopi = input.SelectMany((s,y) => s.Select((c,x) => new Octopus(x,y){Energy = byte.Parse(new []{c})})).ToList();

        var flashes = Enumerable.Range(1, 100).Aggregate(0, (flashes,i) => {
                //WriteOut(octopi);                              
                octopi.Select(o => {o.Flashed = false; o.GainEnergy(); return o;})
                    .Where(o => o.Energy > 9)
                    .ToList()
                    .ForEach(o => {o.Flash(octopi);});
                
                return octopi.Count(o => o.Flashed) + flashes;
            }
        );

        return flashes;
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var octopi = input.SelectMany((s,y) => s.Select((c,x) => new Octopus(x,y){Energy = byte.Parse(new []{c})})).ToList();

        var flashes = Enumerable.Range(1, 10000).First(i => {
                //WriteOut(octopi);                              
                octopi.Select(o => {o.Flashed = false; o.GainEnergy(); return o;})
                    .Where(o => o.Energy > 9)
                    .ToList()
                    .ForEach(o => {o.Flash(octopi);});
                
                return octopi.Count(o => o.Flashed) == octopi.Count();
            }
        );

        return flashes;
    }

    private record Octopus(int x, int y)
    {
        public byte Energy {get; set;} = default!;

        public bool Flashed {get; set;} = default!;

        public void GainEnergy()
        {
            if(Flashed)
                return;

            Energy++;
        }

        public void Flash(IEnumerable<Octopus> otherOctopi)
        {
            if(Flashed)
                return;
            
            if(Energy <= 9)
                throw new InvalidOperationException("Not enough energy");

            Energy = 0;
            Flashed = true;

            GetAdjacent(this, otherOctopi)
                .Select(o => {o.GainEnergy();return o;})
                .Where(o => o.Energy > 9)
                .ToList()
                .ForEach(o => o.Flash(otherOctopi));                           
        }
    }

    private static void WriteOut(IEnumerable<Octopus> octopi)
    {
        octopi.OrderBy(o => o.y)
            .GroupBy(o => o.y)
            .ToList()
            .ForEach(l => Console.WriteLine(string.Join("", l.OrderBy(x => x.x).Select(o => o.Energy.ToString()))));

        Console.WriteLine();
    }

    private static IEnumerable<Octopus> GetAdjacent(Octopus o, IEnumerable<Octopus> points)
    {
        return points.Where(ao => 
            InRange(ao.x, o.x -1, o.x +1) 
            && InRange(ao.y, o.y -1, o.y +1) 
            && ao != o);/*not me*/
    }

    private static bool InRange(int i, int from, int to)
    {
        return i >= from && i <= to;
    }
}
