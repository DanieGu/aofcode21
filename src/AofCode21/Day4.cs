using System;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    //https://adventofcode.com/2021/day/4
    public class Day4
    {
        public static int FirstStar(IEnumerable<string> input)
        {
            var numbersCalled = input.First().Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(s => int.Parse(s)).ToList();
            var boardLines = input.Skip(1);
            var boardSize = boardLines.Count() / boardLines.Where(s => string.IsNullOrWhiteSpace(s)).Count();

            var boards = boardLines.Select((value,index) => new {group = index / boardSize, line = value})
                .GroupBy(bl => bl.group)
                .Select(g => 
                    new BingoBoard(g.Where(gl => !string.IsNullOrWhiteSpace(gl.line))
                        .Select(gl => gl.line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(num => int.Parse(num)).ToArray())
                        .ToArray()))
                .ToArray();
            
            var winningNumber = numbersCalled.First(n => boards.Any(b => b.Tally(n).Bingo));
            var score = boards.First(b => b.Bingo).GetScore(winningNumber);

            return score;
        }

        public static int SecondStar(IEnumerable<string> input)
        {
            var numbersCalled = input.First().Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(s => int.Parse(s)).ToList();
            var boardLines = input.Skip(1);
            var boardSize = boardLines.Count() / boardLines.Where(s => string.IsNullOrWhiteSpace(s)).Count();

            var boards = boardLines.Select((value,index) => new {group = index / boardSize, line = value})
                .GroupBy(bl => bl.group)
                .Select(g => 
                    new BingoBoard(g.Where(gl => !string.IsNullOrWhiteSpace(gl.line))
                        .Select(gl => gl.line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(num => int.Parse(num)).ToArray())
                        .ToArray()))
                .ToArray();
            
            var loser = boards.Select(b => new {winNum = numbersCalled.First(num => b.Tally(num).Bingo), board = b}).OrderByDescending(bp => bp.board.Plays).First();

            var score = loser.board.GetScore(loser.winNum);

            return score;
        }

        private class BingoBoard
        {
            private class Match { public bool Matched; public int Value;}
            private IEnumerable<Match[]> _rows;
            public int Plays = 0;
            private IEnumerable<Match[]> Columns => _rows.First().Select((value,index) => _rows.Select(r => r[index]).ToArray());

            public BingoBoard(IEnumerable<int[]> rows)
            {
                _rows = rows.Select(r => r.Select(i => new Match(){Value = i}).ToArray()).ToList();
            }           

            public bool Bingo => _rows.Any(r => r.All(v => v.Matched)) || Columns.Any(c => c.All(v => v.Matched));

            public BingoBoard Tally(int number)
            {
                Plays++;
                foreach(var value in _rows.SelectMany(r => r).Where(m => m.Value == number))
                {
                    value.Matched = true;
                }
                return this;
            }

            public int GetScore(int lastCalled)
            {
                return _rows.SelectMany(r => r).Where(v => !v.Matched).Sum(v => v.Value) * lastCalled;
            }
        }
    }
}