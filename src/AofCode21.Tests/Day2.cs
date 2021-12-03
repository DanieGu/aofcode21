using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AofCode21.Tests
{
    [TestClass]
    public class Day2
    {
        private enum Direction
        {
            Forward,
            Down,
            Up
        }

        [TestMethod]
        public void First()
        {
            var input = File.ReadAllLines("Day2Input.txt");
            var movements = input.Select(s => Regex.Match(s, @"^(?<dir>[^\s]+)\s+(?<dis>[0-9]+)$"))
                .Select(m => new {
                    dir = (Direction)Enum.Parse(typeof(Direction), m.Groups["dir"].Value, true), 
                    dis = int.Parse(m.Groups["dis"].Value)})
                .ToList();

            var depth = movements.Where(m => m.dir == Direction.Down).Sum(m => m.dis) - movements.Where(m => m.dir == Direction.Up).Sum(m => m.dis);
            var horizontal = movements.Where(m => m.dir == Direction.Forward).Sum(m => m.dis);

            Assert.Inconclusive($"Answer is {horizontal * depth}");
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

        [TestMethod]
        public void Second()
        {
            var input = File.ReadAllLines("Day2Input.txt");
            var movements = input.Select(s => Regex.Match(s, @"^(?<dir>[^\s]+)\s+(?<dis>[0-9]+)$"))
                .Select(m => (
                    dir: (Direction)Enum.Parse(typeof(Direction), m.Groups["dir"].Value, true), 
                    dis: int.Parse(m.Groups["dis"].Value)))
                .ToList();

            var location = Location.FromMovements(movements);

            Assert.Inconclusive($"Answer is {location.Horizontal * location.Depth}");
        }
    }

}