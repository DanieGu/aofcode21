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
    public class Day5Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day5Input.txt");

            var result = AofCode21.Day5.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day5Input.txt");

            var result = AofCode21.Day5.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day5.FirstStar(SampleInput);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day5.SecondStar(SampleInput);

            Assert.AreEqual(12, result);
        }
    }
}