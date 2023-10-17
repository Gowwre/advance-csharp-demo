// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ParallelLINQ;

var result = BenchmarkRunner.Run<SumBenchmark>();
