using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DriverFinder.Core;

namespace DriverFinder.Benchmarks;

[MemoryDiagnoser]
public class NearestDriverBenchmarks
{
    private Driver[] _drivers;
    private Point _order;

    [GlobalSetup]
    public void Setup()
    {
        // Генерируем 10000 водителей на карте 1000x1000
        _drivers = TestDataGenerator.Generate(10_000, 1000, 1000, seed: 13);
        _order = new Point(500, 500);
    }

    [Benchmark(Baseline = true)]
    public IReadOnlyList<Driver> BruteForceSort()
        => new BruteForceSortFinder().FindTop5(_drivers, _order);

    [Benchmark]
    public IReadOnlyList<Driver> HeapBased()
        => new HeapBasedFinder().FindTop5(_drivers, _order);

    [Benchmark]
    public IReadOnlyList<Driver> ManualTop5()
        => new ManualTop5Finder().FindTop5(_drivers, _order);

    [Benchmark]
    public IReadOnlyList<Driver> ArraySort()
        => new ArraySortFinder().FindTop5(_drivers, _order);
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<NearestDriverBenchmarks>();
    }
}