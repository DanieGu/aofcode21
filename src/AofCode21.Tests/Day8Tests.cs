using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AofCode21.Tests
{
    [TestClass]
    public class Day8Tests
    {
        [TestMethod]
        public void Answer1()
        {
            var input = File.ReadAllLines("Day8Input.txt");

            var result = AofCode21.Day8.FirstStar(input);

            Assert.Inconclusive($"{result}");
        }

        [TestMethod]
        public void Answer2()
        {
            var input = File.ReadAllLines("Day8Input.txt");

            var result = AofCode21.Day8.SecondStar(input);

            Assert.Inconclusive($"{result}");
        }

        private string Sample = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";

        private string[] SampleInput => Sample.Split(Environment.NewLine);

        [TestMethod]
        public void Answer1_Test1()
        {
            var result = AofCode21.Day8.FirstStar(SampleInput);

            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Answer2_Test1()
        {
            var result = AofCode21.Day8.SecondStar(SampleInput);

            Assert.AreEqual(61229, result);
        }
    }
}