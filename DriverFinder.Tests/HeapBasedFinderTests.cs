using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DriverFinder.Core;

namespace DriverFinder.Tests;
[TestFixture]
public class HeapBasedFinderTests
{
    private INearestDriverFinder _finder;

    [SetUp]
    public void Setup()
    {
        _finder = new HeapBasedFinder();
    }

    [Test]
    public void FindTop5_ReturnsClosestDriver_WhenOnlyOneExists() // Проверка, если есть один водитель
    {
        var drivers = new[]
        {
            new Driver("d1", 5,5)
        };
        var order = new Point(0,0);
        var result = _finder.FindTop5(drivers, order);

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0].Id, Is.EqualTo("d1"));
    }

    [Test]
    public void FindTop5_ReturnsCorrectOrder_WhenMultipleDriversExist() //Проверка, когда водителей несколько
    {
        var drivers = new[]
        {
            new Driver("d1", 10, 10),
            new Driver("d2", 1,1),
            new Driver("d3", 5,5)
        };
        var order = new Point(0, 0);

        var result = _finder.FindTop5(drivers, order);

        Assert.That(result[0].Id, Is.EqualTo("d2"));
        Assert.That(result[1].Id, Is.EqualTo("d3"));
        Assert.That(result[2].Id, Is.EqualTo("d1"));
    }
}