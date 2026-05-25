using DriverFinder.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DriverFinder.Tests;
[TestFixture]
public class GeneratorTests
{
    [Test]
    public void Generate_ReturnsCorrectNumberOfDrivers()
    {
        int requestedCount = 100;
        var drivers = TestDataGenerator.Generate(requestedCount, 500, 500);

        Assert.That(drivers.Length, Is.EqualTo(requestedCount));
    }
    [Test]
    public void Generate_FirstDriverHasCorrectId()
    {
        var drivers = TestDataGenerator.Generate(10, 500, 500);

        Assert.That(drivers[0].Id, Is.EqualTo("driver_0"));
    }
}