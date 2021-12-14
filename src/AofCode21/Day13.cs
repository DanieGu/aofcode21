namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/13
public class Day13
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var dotStr = input.TakeWhile(s => !s.StartsWith("fold")).Where(s => !string.IsNullOrEmpty(s));
        var dots = dotStr.Select(s => s.Split(",")).Select(a => new Dot(int.Parse(a[0]), int.Parse(a[1]))).ToList();

        var folds = input.SkipWhile(s => !s.StartsWith("fold"))
            .Select(s => s.Replace("fold along", "").Trim().Split("="))
            .Select(ar => new {dir = ar[0], where = int.Parse(ar[1])})
            .Select(f => (FoldOn)(f.dir == "y" ? new FoldOnY(){Where = f.where} : new FoldOnX(){Where = f.where}))
            .ToList();

        dots = folds.First().Fold(dots).ToList();;
        return dots.Distinct().Count();
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var dotStr = input.TakeWhile(s => !s.StartsWith("fold")).Where(s => !string.IsNullOrEmpty(s));
        IEnumerable<Dot> dots = dotStr.Select(s => s.Split(",")).Select(a => new Dot(int.Parse(a[0]), int.Parse(a[1]))).ToList();

        var folds = input.SkipWhile(s => !s.StartsWith("fold"))
            .Select(s => s.Replace("fold along", "").Trim().Split("="))
            .Select(ar => new {dir = ar[0], where = int.Parse(ar[1])})
            .Select(f => (FoldOn)(f.dir == "y" ? new FoldOnY(){Where = f.where} : new FoldOnX(){Where = f.where}))
            .ToList();

        dots = folds.Aggregate(dots, (d,f)  => f.Fold(d).Distinct()).ToList();
        Console.WriteLine();

        WriteOut(dots);

        return 0;
    }

    private record Dot(int x, int y);

    private class FoldOnX : FoldOn
    {
        public override IEnumerable<Dot> Fold(IEnumerable<Dot> dots)
        {
            return dots.Select(d => 
            {
                if(d.x <= Where)
                    return d;

                return new Dot(Where - (d.x - Where), d.y);
            }).ToList();                
        }
    }

    private class FoldOnY : FoldOn
    {
        public override IEnumerable<Dot> Fold(IEnumerable<Dot> dots)
        {
            return dots.Select(d => 
            {
                if(d.y <= Where)
                    return d;

                return new Dot(d.x, Where - (d.y - Where));
            }).ToList();                
        }
    }

    private abstract class FoldOn
    {  
        public int Where {get; set;} 

        public abstract IEnumerable<Dot> Fold(IEnumerable<Dot> dots);
    }

    private static void WriteOut(IEnumerable<Dot> dots)
    {
        var maxX = dots.Max(d => d.x) + 1;
        dots.OrderBy(o => o.y)
            .GroupBy(o => o.y)
            .ToList()
            .ForEach(l => Console.WriteLine(string.Join("", Enumerable.Range(0, maxX).Select(i => l.Any(d => d.x == i) ? "#" : "."))));

        Console.WriteLine();
    }
}
