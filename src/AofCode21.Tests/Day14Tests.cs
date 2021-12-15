namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day14Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day14Input.txt");

        var result = AofCode21.Day14.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day14Input.txt");

        var result = AofCode21.Day14.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day14.FirstStar(SampleInput);

        Assert.AreEqual(1588, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day14.SecondStar(SampleInput);

        Assert.AreEqual(2188189693529, result);
    }
}
