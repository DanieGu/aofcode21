namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day10Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day10Input.txt");

        var result = AofCode21.Day10.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day10Input.txt");

        var result = AofCode21.Day10.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    private string[] SampleInput => Sample.Split(Environment.NewLine);

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day10.FirstStar(SampleInput);

        Assert.AreEqual(26397, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day10.SecondStar(SampleInput);

        Assert.AreEqual(288957, result);
    }
}
