namespace AofCode21;

using System;
using System.Diagnostics;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

//https://adventofcode.com/2021/day/15
public class Day15
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var stopWatch = Stopwatch.StartNew();
        var points = input.SelectMany((s,y) => s.Select((c,x) => new Point(x,y,byte.Parse(new []{c})))).ToList();

        var end = points.MaxBy(p => p.x + p.y) ?? throw new InvalidOperationException("No end");
        var start = points.First(p => p.x == 0 && p.y == 0);

        Dijkstra(start, end, points.ToHashSet());
        var path = new List<Point>(){end};
        BuildSafestPath(path, end);
        path.Reverse();

        WriteOut(points, path);
        Console.WriteLine($"Solution in {stopWatch.Elapsed.TotalSeconds}");

        return path.Skip(1).Sum(p => p.risk);
    }

    private static void BuildSafestPath(IList<Point> points, Point point)
    {
        if(point.SafestToStart is null)
            return;

        points.Add(point.SafestToStart);
        BuildSafestPath(points, point.SafestToStart);
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var stopWatch = Stopwatch.StartNew();
        var points = input.SelectMany((s,y) => s.Select((c,x) => new Point(x,y,byte.Parse(new []{c})))).ToList();
        //replicate to the right
        points = points.GroupBy(p => p.y)
            .SelectMany(g => 
                Enumerable.Range(0,5)
                .SelectMany(i => g.Select(p => new Point(p.x + g.Count() * i, g.Key,p.risk + i > 9 ? p.risk + i -9 : p.risk + i)))).ToList();
        //replicate down
        points = points.GroupBy(p => p.x)
            .SelectMany(g => 
                Enumerable.Range(0,5)
                .SelectMany(i => g.Select(p => new Point(g.Key, p.y + g.Count() * i,p.risk + i > 9 ? p.risk + i -9 : p.risk + i)))).ToList();

        var end = points.MaxBy(p => p.x + p.y) ?? throw new InvalidOperationException("No end");
        var start = points.First(p => p.x == 0 && p.y == 0);

        Dijkstra(start, end, points.ToHashSet());
        var path = new List<Point>(){end};
        BuildSafestPath(path, end);
        path.Reverse();

        WriteOut(points, path);
        Console.WriteLine($"Solution in {stopWatch.Elapsed.TotalSeconds}");

        return path.Skip(1).Sum(p => p.risk);
    }

    private static void WriteOut(IEnumerable<Point> allPoints, IEnumerable<Point> visited)
    {
        Console.WriteLine();

        allPoints.GroupBy(p => p.y)
            .OrderBy(g => g.Key)
            .ToList()
            .ForEach(g => {
                Console.WriteLine(string.Join("", g.OrderBy(p => p.x).Select(p => visited.Contains(p) ? "#" : p.risk.ToString())));
            });
    }

    // Implementation patterned after https://www.codeproject.com/Articles/1221034/Pathfinding-Algorithms-in-Csharp
    private static void Dijkstra(Point start, Point end, HashSet<Point> allPoints)
    {
        var priorityQueue = new List<Point>();
        priorityQueue.Add(start);
        start.MinRiskToStart = 0;

        while(priorityQueue.Any())
        {
            priorityQueue = priorityQueue.OrderBy(p => p.MinRiskToStart).ToList();
            var point = priorityQueue.First();
            priorityQueue.Remove(point);

            foreach(var connectedNode in GetAdjacent(point, allPoints).OrderBy(p => p.risk))
            {
                if(connectedNode.Visited)
                    continue;

                if(connectedNode.MinRiskToStart == null || 
                    point.MinRiskToStart + connectedNode.risk < connectedNode.MinRiskToStart)
                {
                    connectedNode.MinRiskToStart = point.MinRiskToStart + connectedNode.risk;
                    connectedNode.SafestToStart = point;
                    if(!priorityQueue.Contains(connectedNode))
                        priorityQueue.Add(connectedNode);
                }
            }
            point.Visited = true;
            if(point == end)
                return;
        }
    }

    private static IEnumerable<Point> GetAdjacent(Point p, HashSet<Point> allPoints)
    {       
        foreach(var point in new []{
            new Point(p.x, p.y + 1, 0),
            new Point(p.x, p.y - 1, 0),
            new Point(p.x + 1, p.y, 0),
            new Point(p.x - 1, p.y, 0)
        })
        {
            if(allPoints.TryGetValue(point, out var pointRisk))
                yield return pointRisk;
        }
    }

    private class Point : ValueObject
    {
        public int x {get;}
        public int y {get;}
        public int risk {get;}

        public bool Visited { get; set; } = false;

        public int? MinRiskToStart { get; set; }

        public Point? SafestToStart { get; set; }

        public Point(int x, int y, int risk)
        {
            this.x = x;
            this.y = y;
            this.risk = risk;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return x;
            yield return y;
        }
    }
}
