using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    //https://adventofcode.com/2021/day/8
    public class Day8
    {
        public static Int64 FirstStar(IEnumerable<string> input)
        {
            var outputEntries = input.SelectMany(s => s.Split('|', StringSplitOptions.TrimEntries).Last().Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                .Where(o => new []{2,3,4,7}.Contains(o.Length));
            
            return outputEntries.Count();
        }

        public static Int64 SecondStar(IEnumerable<string> input)
        {
            var answer = input.Select(s => new { patterns = s.Split('|', StringSplitOptions.TrimEntries)
                                                .First()
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                .OrderBy(s => s.Length)
                                                .ToArray(),
                                                output = s.Split('|', StringSplitOptions.TrimEntries)
                                                .Last()
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                .ToArray()})
                                .Select(r => {
                                    var f = IntersectAll(r.patterns[0], r.patterns.Where(s => s.Length == 6)).Single();
                                    var c = r.patterns[0].Except(new []{f}).Single();
                                    var a = r.patterns[1].Except(new []{f,c}).Single();
                                    var b = IntersectAll(r.patterns[2], r.patterns.Where(s => s.Length == 6)).Except(new []{c,f}).Single();
                                    var d = r.patterns[2].Except(new []{b,c,f}).Single();
                                    var g = IntersectAll(r.patterns[9], r.patterns.Where(s => s.Length == 6)).Except(new []{a,b,c,d,f}).Single();
                                    var e = r.patterns[9].Except(new []{a,b,c,d,f,g}).Single();
                                    var map = new Dictionary<char,char>(){{a,'a'},{b,'b'},{c,'c'},{d,'d'},{e,'e'},{f,'f'},{g,'g'}};

                                    return Digit.Combine(r.output.Select(s => Digit.FromSegments(Translate(s, map))));
                                })
                                .Sum();

            return answer;
        }

        private static string Translate(string input, IDictionary<char,char> map)
        {
            return new string(input.Select(c => map[c]).OrderBy(c => c).ToArray());
        }

        private static IEnumerable<char> IntersectAll(string input, IEnumerable<string> strings)
        {
            if(strings == null || !strings.Any())
                return Enumerable.Empty<char>();

            var intersection = input.Intersect(strings.First());
            if(strings.Count() > 1)
                intersection = intersection.Intersect(IntersectAll(input, strings.Skip(1)));

            return intersection;
        }

        private class Digit
        {
            public static Digit Zero = new Digit(0, "abcefg");
            public static Digit One = new Digit(1, "cf");
            public static Digit Two = new Digit(2, "acdeg");
            public static Digit Three = new Digit(3, "acdfg");
            public static Digit Four = new Digit(4, "bcdf");
            public static Digit Five = new Digit(5, "abdfg");
            public static Digit Six = new Digit(6, "abdefg");
            public static Digit Seven = new Digit(7, "acf");
            public static Digit Eight = new Digit(8, "abcdefg");
            public static Digit Nine = new Digit(9, "abcdfg");

            public static Digit[] All = new []{Zero,One,Two,Three,Four,Five,Six,Seven,Eight,Nine};
            public string Segments {get;}

            public int Num { get; }

            public int SegmentCount => Segments.Length;

            public static Digit FromSegments(string segments)
            {
                return All.Single(s => s.Segments == segments);
            }

            public static int Combine(IEnumerable<Digit> digits)
            {
                return int.Parse(string.Join("", digits.Select(d => d.Num.ToString())));
            }

            private Digit(int num, string segments)
            {
                Num = num;
                Segments = segments;
            }    
        }
    }
}