namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day9Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day9Input.txt");

        var result = AofCode21.Day9.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day9Input.txt");

        var result = AofCode21.Day9.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day9.FirstStar(SampleInput);

        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day9.SecondStar(SampleInput);

        Assert.AreEqual(1134, result);
    }
}
