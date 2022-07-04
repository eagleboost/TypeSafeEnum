namespace TypeSafeEnumApp;

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

public class Benchmark_All
{
  [GlobalSetup]
  public void Setup()
  {
    ////Trigger the static constructors
    RuntimeHelpers.RunClassConstructor(typeof(TypeSafeStatus).TypeHandle);
    RuntimeHelpers.RunClassConstructor(typeof(EnumParser<Status>).TypeHandle);
  }
  
  [Benchmark(Baseline = true)]
  public void Enum_All()
  {
    var items = Enum.GetValues<Status>();
  }
    
  [Benchmark]
  public void EnumBox_All()
  {
    var items = EnumParser<Status>.AllItems;
  }
    
  [Benchmark]
  public void TypeSafeEnum_All()
  {
    var items = TypeSafeStatus.AllItems;
  } 
}