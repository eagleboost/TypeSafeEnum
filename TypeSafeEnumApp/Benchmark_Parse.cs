namespace TypeSafeEnumApp;

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

public class Benchmark_Parse
{
  [GlobalSetup]
  public void Setup()
  {
    ////Trigger the static constructors
    RuntimeHelpers.RunClassConstructor(typeof(TypeSafeStatus).TypeHandle);
    RuntimeHelpers.RunClassConstructor(typeof(EnumParser<Status>).TypeHandle);
  }
  
  [Benchmark(Baseline = true)]
  [Arguments("New")]
  [Arguments("Open")]
  [Arguments("Cancelled")]
  public void Enum_Parse(string status)
  {
    Enum.Parse(typeof(Status), status);
  }
    
  [Benchmark]
  [Arguments("New")]
  [Arguments("Open")]
  [Arguments("Cancelled")]
  public void EnumBox_Parse(string status)
  {
    EnumParser<Status>.Parse(status);
  }
    
  [Benchmark]
  [Arguments("New")]
  [Arguments("Open")]
  [Arguments("Cancelled")]
  public void TypeSafeEnum_Parse(string status)
  {
    TypeSafeStatus.Parse(status);
  } 
}