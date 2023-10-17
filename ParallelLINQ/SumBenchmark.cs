using BenchmarkDotNet.Attributes;

namespace ParallelLINQ;

public class SumBenchmark
{
    private long[] sampleArray;

    [GlobalSetup]
    public void Setup()
    {
        sampleArray = new long[100000000];
        long value = 0;
        for (var i = 0; i < sampleArray.Length; i++) sampleArray[i] = value++;
    }

    [Benchmark]
    public long SumWithParallelFor()
    {
        long sum = 0;
        Parallel.For<long>(0, sampleArray.Length, () => 0, (i, loop, subtotal) =>
            {
                subtotal += sampleArray[i];
                return subtotal;
            },
            (x) => Interlocked.Add(ref sum, x));
        return sum;
    }

    [Benchmark]
    public long SumWithForeach()
    {
        long sum = 0;
        foreach (var l in sampleArray)
        {
            sum += l;
        }

        return sum;
    }

    [Benchmark]
    public long SumWithAsParallelSum()
    {
        return sampleArray.AsParallel().Sum();
    }

    [Benchmark]
    public long SumWithSum()
    {
        return sampleArray.Sum();
    }


    [Benchmark]
    public long SumWithAggregate()
    {
        return sampleArray.Aggregate((l, l1) => l + l1);
    }

    [Benchmark]
    public long SumWithAsParallelAggregate()
    {
        return sampleArray.AsParallel().Aggregate(((l, l1) => l + l1));
    }
}