using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    public class Day5
    {
        public static int FirstStar(IEnumerable<string> input)
        {
            var intersects = input.Select(s => Regex.Match(s, @"^(?<x1>[0-9]+),(?<y1>[0-9]+)\s*->\s*(?<x2>[0-9]+),(?<y2>[0-9]+)$"))
                            .Select(m => new {
                                x1 = int.Parse(m.Groups["x1"].Value),
                                y1 = int.Parse(m.Groups["y1"].Value),
                                x2 = int.Parse(m.Groups["x2"].Value),
                                y2 = int.Parse(m.Groups["y2"].Value)
                                })
                            .Where(l => l.x1 == l.x2 || l.y1 == l.y2)
                            .SelectMany(l => l.x1 == l.x2 ? 
                                Enumerable.Range(Math.Min(l.y1, l.y2), Math.Abs(l.y1 - l.y2)+1).Select(y => new {x = l.x1, y})
                                : Enumerable.Range(Math.Min(l.x1, l.x2), Math.Abs(l.x1 - l.x2)+1).Select(x => new {x, y = l.y1}))
                            .GroupBy(p => p)
                            .Where(g => g.Count() > 1)
                            .Count();

            return intersects;
        }

        public static int SecondStar(IEnumerable<string> input)
        {
            var intersects = input.Select(s => Regex.Match(s, @"^(?<x1>[0-9]+),(?<y1>[0-9]+)\s*->\s*(?<x2>[0-9]+),(?<y2>[0-9]+)$"))
                            .Select(m => new {
                                x1 = int.Parse(m.Groups["x1"].Value),
                                y1 = int.Parse(m.Groups["y1"].Value),
                                x2 = int.Parse(m.Groups["x2"].Value),
                                y2 = int.Parse(m.Groups["y2"].Value)
                                })
                            .Select(l => new Line(new Point(){X = l.x1, Y = l.y1}, new Point(){X = l.x2, Y = l.y2}))
                            .SelectMany(l => l.Points)
                            .GroupBy(p => p)
                            .Where(g => g.Count() > 1)
                            .Count();

            return intersects;
        }

        private struct Point { public int X,Y; } 

        private class Line
        {
            public IEnumerable<Point> Points { get; }

            public Line(Point start, Point end)
            {
                if(start.X == end.X)
                    Points = Enumerable.Range(Math.Min(start.Y, end.Y), Math.Abs(start.Y - end.Y)+1).Select(y => new Point(){X =start.X, Y = y}).ToArray();   
                else if(start.Y == end.Y)
                    Points = Enumerable.Range(Math.Min(start.X, end.X), Math.Abs(start.X - end.X)+1).Select(x => new Point(){X =x, Y = start.Y}).ToArray(); 
                else
                {
                    if(end.X < start.X)
                        (start,end) = (end,start);  
                    var yModifier = end.Y > start.Y ? 1 : -1;                 
                    Points = Enumerable.Range(start.X, end.X - start.X +1).Select((x, index) => new Point(){X =x, Y = start.Y + (index * yModifier)}).ToArray();
                }
            }        
        }
    }
}