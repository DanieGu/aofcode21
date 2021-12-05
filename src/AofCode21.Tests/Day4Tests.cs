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
    public class Day4
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day4Input.txt");

            var result = AofCode21.Day4.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer1_Test1()
        {
            var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            var result = AofCode21.Day4.FirstStar(input.Split(Environment.NewLine));

            Assert.AreEqual(result, 4512);
        }

                [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day4Input.txt");

            var result = AofCode21.Day4.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            var result = AofCode21.Day4.SecondStar(input.Split(Environment.NewLine));

            Assert.AreEqual(result, 1924);
        }
    }
}