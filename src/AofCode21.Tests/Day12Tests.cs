namespace AofCode21.Tests;

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Day12Tests
{
    [TestMethod]
    public void Answer1()
    {
        var input = File.ReadAllLines("Day12Input.txt");

        var result = AofCode21.Day12.FirstStar(input);

        Assert.Inconclusive($"{result}");
    }

    [TestMethod]
    public void Answer2()
    {
        var input = File.ReadAllLines("Day12Input.txt");

        var result = AofCode21.Day12.SecondStar(input);

        Assert.Inconclusive($"{result}");
    }

    private string Sample1 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    private string Sample2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

    private string Sample3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";



    [TestMethod]
    public void Answer1_Test1()
    {
        var result = AofCode21.Day12.FirstStar(Sample1.Split(Environment.NewLine));

        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void Answer1_Test2()
    {
        var result = AofCode21.Day12.FirstStar(Sample2.Split(Environment.NewLine));

        Assert.AreEqual(19, result);
    }

    [TestMethod]
    public void Answer1_Test3()
    {
        var result = AofCode21.Day12.FirstStar(Sample3.Split(Environment.NewLine));

        Assert.AreEqual(226, result);
    }

    [TestMethod]
    public void Answer2_Test1()
    {
        var result = AofCode21.Day12.SecondStar(Sample1.Split(Environment.NewLine));

        Assert.AreEqual(36, result);
    }

    [TestMethod]
    public void Answer2_Test2()
    {
        var result = AofCode21.Day12.SecondStar(Sample2.Split(Environment.NewLine));

        Assert.AreEqual(103, result);
    }

    [TestMethod]
    public void Answer2_Test3()
    {
        var result = AofCode21.Day12.SecondStar(Sample3.Split(Environment.NewLine));

        Assert.AreEqual(3509, result);
    }
}
