using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AofCode21
{
    //https://adventofcode.com/2021/day/2
    public class Day2
    {
        public static int FirstStar(IEnumerable<string> input)
        {
            var movements = input.Select(s => Regex.Match(s, @"^(?<dir>[^\s]+)\s+(?<dis>[0-9]+)$"))
                .Select(m => new {
                    dir = (Direction)Enum.Parse(typeof(Direction), m.Groups["dir"].Value, true), 
                    dis = int.Parse(m.Groups["dis"].Value)})
                .ToList();

            var depth = movements.Where(m => m.dir == Direction.Down).Sum(m => m.dis) - movements.Where(m => m.dir == Direction.Up).Sum(m => m.dis);
            var horizontal = movements.Where(m => m.dir == Direction.Forward).Sum(m => m.dis);

            return horizontal * depth;
        }

        public static int SecondStar(IEnumerable<string> input)
        {
            var movements = input.Select(s => Regex.Match(s, @"^(?<dir>[^\s]+)\s+(?<dis>[0-9]+)$"))
                .Select(m => (
                    dir: (Direction)Enum.Parse(typeof(Direction), m.Groups["dir"].Value, true), 
                    dis: int.Parse(m.Groups["dis"].Value)))
                .ToList();

            var location = Location.FromMovements(movements);

            return location.Horizontal * location.Depth;
        }

        private enum Direction
        {
            Forward,
            Down,
            Up
        }

        private class Location
        {
            public int Depth,Horizontal,Aim = 0;

            public static Location FromMovements(IEnumerable<(Direction dir, int dis)> movements)
            {
                var location = new Location();
                foreach(var movement in movements)
                    location.Move(movement);

                return location;
            }

            public void Move((Direction dir, int dis) movement)
            {
                if(movement.dir == Direction.Down)
                    Aim += movement.dis;
                else if(movement.dir == Direction.Up)
                    Aim -= movement.dis;
                else if(movement.dir == Direction.Forward)
                {
                    Horizontal += movement.dis;
                    Depth += Aim * movement.dis;
                }
            }
        }
    }

}