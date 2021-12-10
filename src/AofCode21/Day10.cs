namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/10
public class Day10
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var badLines = input.Select(s => { 
            var stack = new Stack<CharacterSet>();
            var found = s.FirstOrDefault(c => {
                var cs = CharacterSet.Find(c);
                if(cs.IsClosing(c))
                {
                    if(stack.TryPop(out var opening)
                        && !opening.Contains(c))
                    {
                        return true;
                    }
                }
                else
                {
                    stack.Push(CharacterSet.Find(c));
                }

                return false;
            });
            return new {s, found};
        })
        .Where(x => x.found != default(char))
        .ToList();

        return badLines.Select(bl => CharacterSet.Find(bl.found).Points).Sum();
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var goodLines = input.Select(s => { 
            var stack = new Stack<CharacterSet>();
            var found = s.FirstOrDefault(c => {
                var cs = CharacterSet.Find(c);
                if(cs.IsClosing(c))
                {
                    if(stack.TryPop(out var opening)
                        && !opening.Contains(c))
                    {
                        return true;
                    }
                }
                else
                {
                    stack.Push(CharacterSet.Find(c));
                }

                return false;
            });
            return new {s, found, stack};
        })
        .Where(x => x.found == default(char))
        .ToList();

        return goodLines
            .Select(gl => gl.stack.Select(cs => cs.CompletePoints).Aggregate(0L, (a,p) => (a * 5) + p))
            .OrderBy(i => i)
            .Skip((int)Math.Floor(goodLines.Count/2d))
            .First();
    }

    private record CharacterSet(char Opening, char Closing, int Points, int CompletePoints)
    {
        public static CharacterSet[] All = new []{
            new CharacterSet('(',')',3,1),
            new CharacterSet('[',']',57,2),
            new CharacterSet('{','}',1197,3),
            new CharacterSet('<','>',25137,4)
            };

        public static CharacterSet Find(char c)
        {
            return All.First(cs => cs.Contains(c));
        }

        public bool Contains(Char c) { return Opening == c || Closing == c; }

        public bool IsOpening(Char c) { return Opening == c; } 
        
        public bool IsClosing(Char c) { return Closing == c; }
    }
}
