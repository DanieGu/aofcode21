namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/14
public class Day14
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var polymer = new Polymer(input.First());

        var insertions = input.SkipWhile(s => !s.Contains("->"))
            .Select(s => s.Split("->", StringSplitOptions.TrimEntries))
            .Select(ar => new Insertion(ar[1].Single(), new CharPair(ar[0].First(), ar[0].Last())))
            .ToList();

        polymer = Enumerable.Range(0, 10).Aggregate(polymer, (p,i) => { p.Insert(insertions); return p;});

        var characterCount = polymer.CharacterCount.OrderByDescending(cc => cc.Value).ToList();
        return characterCount.First().Value - characterCount.Last().Value;
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var polymer = new Polymer(input.First());

        var insertions = input.SkipWhile(s => !s.Contains("->"))
            .Select(s => s.Split("->", StringSplitOptions.TrimEntries))
            .Select(ar => new Insertion(ar[1].Single(), new CharPair(ar[0].First(), ar[0].Last())))
            .ToList();

        polymer = Enumerable.Range(0, 40).Aggregate(polymer, (p,i) => { p.Insert(insertions); return p;});

        var characterCount = polymer.CharacterCount.OrderByDescending(cc => cc.Value).ToList();
        return characterCount.First().Value - characterCount.Last().Value;
    }

    private class Polymer
    {
        public IDictionary<CharPair, Int64> CharacterPairs { get; }

        public IDictionary<Char, Int64> CharacterCount { get; }
            
        public Polymer(string elements)
        {
            CharacterPairs = elements.Take(0..^1)
                .Select((c,i) => new CharPair(c, elements.ElementAt(i + 1)))
                .GroupBy(p => p)
                .ToDictionary(g => g.Key, g => (Int64)g.Count());

            CharacterCount = elements.GroupBy(c => c).ToDictionary(g => g.Key, g => (Int64)g.Count());
        }

        private void Add(Char c, Int64 count)
        {
            if(!CharacterCount.ContainsKey(c))
                CharacterCount[c] = 0;

            CharacterCount[c] = CharacterCount[c] + count;
        }

        private void Add(CharPair pair, Int64 count)
        {
            if(!CharacterPairs.ContainsKey(pair))
                CharacterPairs[pair] = 0;

            CharacterPairs[pair] = CharacterPairs[pair] + count;
        }

        public void Insert(IEnumerable<Insertion> insertions)
        {           
            var actions = insertions.Where(i => CharacterPairs.ContainsKey(i.between))
                .Select(i => (i, count: CharacterPairs[i.between]))
                .ToList()
                .Select<(Insertion i, long count), Action>(a => () => {
                    Add(a.i.insert, a.count);
                    Add(a.i.between, a.count * -1);
                    Add(new CharPair(a.i.between.left, a.i.insert), a.count);
                    Add(new CharPair(a.i.insert, a.i.between.right), a.count);
            }).ToList();

            actions.ForEach(a => a());
        }
    }

    private record CharPair(Char left, Char right);

    private record Insertion(Char insert, CharPair between);
}
