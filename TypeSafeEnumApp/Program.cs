// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using TypeSafeEnumApp;

public class Program
{
  public static void Main(string[] args)
  {
    BenchmarkRunner.Run<Benchmark_Parse>();
    BenchmarkRunner.Run<Benchmark_All>();
    BenchmarkRunner.Run<Benchmark_ToString>();
  }
}