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
    public class Day7Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day7Input.txt");

            var result = AofCode21.Day7.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day7Input.txt");

            var result = AofCode21.Day7.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"16,1,2,0,4,2,7,1,2,14";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day7.FirstStar(SampleInput);

            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day7.SecondStar(SampleInput);

            Assert.AreEqual(168, result);
        }
    }
}