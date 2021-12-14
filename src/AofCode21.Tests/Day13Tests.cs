namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day13Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day13Input.txt");

        var result = AofCode21.Day13.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day13Input.txt");

        var result = AofCode21.Day13.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day13.FirstStar(SampleInput);

        Assert.AreEqual(17, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day13.SecondStar(SampleInput);

        Assert.AreEqual(0, result);
    }
}
