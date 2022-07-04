namespace TypeSafeEnumApp;

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

public class Benchmark_ToString
{
  [GlobalSetup]
  public void Setup()
  {
    ////Trigger the static constructors
    RuntimeHelpers.RunClassConstructor(typeof(TypeSafeStatus).TypeHandle);
    RuntimeHelpers.RunClassConstructor(typeof(EnumParser<Status>).TypeHandle);
  }
  
  [Benchmark(Baseline = true)]
  public void Enum_ToString()
  {
    var str = Status.New.ToString();
  }
    
  [Benchmark]
  public void EnumBox_ToString()
  {
    var str = EnumBox<Status>.Box(Status.New).ToString();
  }
    
  [Benchmark]
  public void TypeSafeEnum_ToString()
  {
    var str = TypeSafeStatus.New.ToString();
  } 
}