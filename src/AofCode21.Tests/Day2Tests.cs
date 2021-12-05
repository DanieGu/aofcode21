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
    public class Day2Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day2Input.txt");

            var result = AofCode21.Day2.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day2Input.txt");

            var result = AofCode21.Day2.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day2.FirstStar(SampleInput);

            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day2.SecondStar(SampleInput);

            Assert.AreEqual(900, result);
        }
    }
}