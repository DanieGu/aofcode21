using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AofCode21.Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day3Input.txt");

            var result = AofCode21.Day3.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer1_Test1()
        {
            var input = new string[]{
"00100",
"11110",
"10110",
"10111",
"10101",
"01111",
"00111",
"11100",
"10000",
"11001",
"00010",
"01010"
            };

            var result = AofCode21.Day3.FirstStar(input);

            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day3Input.txt");

            var result = AofCode21.Day3.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var input = new string[]{
"00100",
"11110",
"10110",
"10111",
"10101",
"01111",
"00111",
"11100",
"10000",
"11001",
"00010",
"01010"
            };

            var result = AofCode21.Day3.SecondStar(input);

            Assert.AreEqual(230, result);
        }
    }
}