namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day16Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day16Input.txt");

        var result = AofCode21.Day16.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day16Input.txt");

        var result = AofCode21.Day16.SecondStar(input);
 
        Assert.Inconclusive($"{result}");
    }

    private string Sample1 = @"8A004A801A8002F478";
    private string Sample2 = @"620080001611562C8802118E34";

    private string Sample3 = @"C0015000016115A2E0802F182340";
    private string Sample4 = @"A0016C880162017C3686B18A3D4780";

    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day16.FirstStar(new []{Sample1});

        Assert.AreEqual(16, result);
    }

    [TestMethod]
    public void Answer1_Test2()
    {
        var result = AofCode21.Day16.FirstStar(new []{Sample2});

        Assert.AreEqual(12, result);
    }
    
    [TestMethod]
    public void Answer1_Test3()
    {
        var result = AofCode21.Day16.FirstStar(new []{Sample3});

        Assert.AreEqual(23, result);
    }
    
    [TestMethod]
    public void Answer1_Test4()
    {
        var result = AofCode21.Day16.FirstStar(new []{Sample4});

        Assert.AreEqual(31, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day16.SecondStar(new []{"C200B40A82"});

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Answer2_Test2()
    {
        var result = AofCode21.Day16.SecondStar(new []{"04005AC33890"});

        Assert.AreEqual(54, result);
    }

    [TestMethod]
    public void Answer2_Test3()
    {
        var result = AofCode21.Day16.SecondStar(new []{"880086C3E88112"});

        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Answer2_Test4()
    {
        var result = AofCode21.Day16.SecondStar(new []{"CE00C43D881120"});

        Assert.AreEqual(9, result);
    }

    [TestMethod]
    public void Answer2_Test5()
    {
        var result = AofCode21.Day16.SecondStar(new []{"D8005AC2A8F0"});

        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Answer2_Test6()
    {
        var result = AofCode21.Day16.SecondStar(new []{"F600BC2D8F"});

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Answer2_Test7()
    {
        var result = AofCode21.Day16.SecondStar(new []{"9C005AC2F8F0"});

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Answer2_Test8()
    {
        var result = AofCode21.Day16.SecondStar(new []{"9C0141080250320F1802104A08"});

        Assert.AreEqual(1, result);
    }
}
