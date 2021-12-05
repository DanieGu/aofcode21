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
    public class Day1Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day1Input.txt");

            var result = AofCode21.Day1.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day1Input.txt");

            var result = AofCode21.Day1.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"199
200
208
210
200
207
240
269
260
263";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day1.FirstStar(SampleInput);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day1.SecondStar(SampleInput);

            Assert.AreEqual(5, result);
        }
    }
}