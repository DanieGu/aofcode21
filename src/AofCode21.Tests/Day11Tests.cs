namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day11Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day11Input.txt");

        var result = AofCode21.Day11.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day11Input.txt");

        var result = AofCode21.Day11.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day11.FirstStar(SampleInput);

        Assert.AreEqual(1656, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day11.SecondStar(SampleInput);

        Assert.AreEqual(195, result);
    }
}
