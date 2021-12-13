namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/12
public class Day12
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var caves = new List<Cave>();
        input.Select(s => {var split = s.Split("-"); return new {l = split[0], r = split[1]};})
            .ToList()
            .ForEach(lc => {
                var caveL = FindOrCreate(caves, c => c.Name == lc.l, () => new Cave(lc.l));
                var caveR = FindOrCreate(caves, c => c.Name == lc.r, () => new Cave(lc.r));
                caveL.LinkedCaves.Add(caveR);
                caveR.LinkedCaves.Add(caveL);
            });

        var visitors = new CaveVisitor(cvs => cvs.Where(c => !c.IsBig || c.IsStart).GroupBy(c => c.Name).Any(g => g.Count() > 1))
            .Visit(caves.Single(c => c.IsStart)).ToList();

        return visitors.Count();
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var caves = new List<Cave>();
        input.Select(s => {var split = s.Split("-"); return new {l = split[0], r = split[1]};})
            .ToList()
            .ForEach(lc => {
                var caveL = FindOrCreate(caves, c => c.Name == lc.l, () => new Cave(lc.l));
                var caveR = FindOrCreate(caves, c => c.Name == lc.r, () => new Cave(lc.r));
                caveL.LinkedCaves.Add(caveR);
                caveR.LinkedCaves.Add(caveL);
            });

        var visitors = new CaveVisitor(cvs => cvs.Count(c => c.IsStart) > 1
                || cvs.Where(c => !c.IsBig).GroupBy(c => c.Name).OrderByDescending(g => g.Count()).Take(2).Sum(g => g.Count()) > 3)
            .Visit(caves.Single(c => c.IsStart)).ToList();

        return visitors.Count();
    }

    private static T FindOrCreate<T>(IList<T> list, Func<T, bool> predicate, Func<T> creator)
    {
        var t = list.FirstOrDefault(predicate);
        if(EqualityComparer<T>.Default.Equals(t, default(T)))
        {
            t = creator();
            list.Add(t);
        }
        return t;
    }

    private class CaveVisitor
    {
        private IList<Cave> _visited;
        public IEnumerable<Cave> Visited => _visited;

        public bool IsComplete => _visited.Last().IsEnd;

        private Func<IEnumerable<Cave>, bool> _validationRules;

        public bool IsInvalid => _validationRules(Visited);

        public CaveVisitor(Func<IEnumerable<Cave>, bool> validationRules)
            : this(Enumerable.Empty<Cave>(), validationRules)
        {
        }

        public CaveVisitor(IEnumerable<Cave> visited, Func<IEnumerable<Cave>, bool> validationRules)
        {
            _validationRules = validationRules;
            _visited = new List<Cave>(visited);      
        }

        public IEnumerable<CaveVisitor> Visit(Cave cave)
        {
            _visited.Add(cave);
            if(cave.IsEnd || IsInvalid)
                return new []{this};
            
            return cave.LinkedCaves.SelectMany(lc => 
                new CaveVisitor(Visited, _validationRules).Visit(lc).Where(cv => !cv.IsInvalid).ToList())
                .ToList();
        }
    }

    private record Cave(string Name)
    {
        public bool IsBig => Name == Name.ToUpper();

        public bool IsStart => Name == "start";

        public bool IsEnd => Name == "end";

        public IList<Cave> LinkedCaves { get; } = new List<Cave>();
    }
}
