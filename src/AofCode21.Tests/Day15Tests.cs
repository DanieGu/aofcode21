namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day15Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day15Input.txt");

        var result = AofCode21.Day15.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day15Input.txt");

        var result = AofCode21.Day15.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day15.FirstStar(SampleInput);

        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day15.SecondStar(SampleInput);

        Assert.AreEqual(315, result);
    }
}
