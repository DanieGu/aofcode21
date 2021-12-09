namespace AofCode21;

using System;
using System.Collections.Generic;
using System.Linq;

//https://adventofcode.com/2021/day/9
public class Day9
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var points = input.SelectMany((s,y) => s.Select((c,x) => new {x,y,i = byte.Parse(new []{c})})).ToList();
        var lowPoints = points.Where(p => points.Where(ap => (ap.x == p.x && (ap.y == p.y +1 || ap.y == p.y -1))||(ap.y == p.y && (ap.x == p.x +1 || ap.x == p.x -1))).All(ap => ap.i > p.i)).ToList();

        return lowPoints.Sum(p => 1 + p.i);
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var points = input.SelectMany((s,y) => s.Select((c,x) => new GridPoint(x,y,byte.Parse(new []{c})))).ToList();
        
        var lowPoints = points.Where(p => GetAdjacent(p, points).All(ap => ap.i > p.i)).ToList();

        var basins = lowPoints.Select(lp => new Basin(lp).FillBasin(points))
            .OrderByDescending(b => b.Points.Count());
        
        var result = basins.Take(3)
            .Aggregate(1, (i,b) => b.Points.Count() * i);

        return result;
    }

    private static IEnumerable<GridPoint> GetAdjacent(GridPoint p, IEnumerable<GridPoint> points)
    {
        return points.Where(ap => (ap.x == p.x && (ap.y == p.y +1 || ap.y == p.y -1))||(ap.y == p.y && (ap.x == p.x +1 || ap.x == p.x -1)));
    }

    private record GridPoint(int x, int y, byte i);

    private class Basin
    {
        public Basin(GridPoint lowPoint)
        {
            Points = new []{lowPoint};
        }

        public IEnumerable<GridPoint> Points {get; private set; }

        public Basin FillBasin(IEnumerable<GridPoint> allPoints)
        {
            var adjacent = Points.SelectMany(p => GetAdjacent(p, allPoints).Where(p => p.i < 9).Except(Points)).ToList();
            if(!adjacent.Any())
                return this;

            Points = Points.Concat(adjacent).Distinct().ToList();
            FillBasin(allPoints);

            return this;           
        }
    }
}