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
    public class Day6Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day6Input.txt");

            var result = AofCode21.Day6.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day6Input.txt");

            var result = AofCode21.Day6.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"3,4,3,1,2";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day6.FirstStar(SampleInput);

            Assert.AreEqual(5934, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day6.SecondStar(SampleInput);

            Assert.AreEqual(26984457539, result);
        }
    }
}