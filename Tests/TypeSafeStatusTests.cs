namespace Tests;

using System.ComponentModel;
using TypeSafeEnumApp;

public class TypeSafeStatusTests
{
  [Test]
  public void Test_01_ParseById()
  {
    Assert.That(TypeSafeStatus.Parse("0"), Is.EqualTo(TypeSafeStatus.New));
    Assert.That(TypeSafeStatus.Parse("1"), Is.EqualTo(TypeSafeStatus.Open));
    Assert.That(TypeSafeStatus.Parse("2"), Is.EqualTo(TypeSafeStatus.Cancelled));
  }
  
  [Test]
  public void Test_02_ParseByName()
  {
    Assert.That(TypeSafeStatus.Parse("New"), Is.EqualTo(TypeSafeStatus.New));
    Assert.That(TypeSafeStatus.Parse("Open"), Is.EqualTo(TypeSafeStatus.Open));
    Assert.That(TypeSafeStatus.Parse("Cancelled"), Is.EqualTo(TypeSafeStatus.Cancelled));
  }
  
  [Test]
  public void Test_03_ParseFail()
  {
    Assert.Throws<ArgumentException>(() => TypeSafeStatus.Parse("New1"));
    Assert.That(TypeSafeStatus.TryParse("New1", out _), Is.False);
  }
  
  [Test]
  public void Test_04_ToString()
  {
    Assert.That(TypeSafeStatus.New.ToString(), Is.EqualTo("New"));
    Assert.That(TypeSafeStatus.Open.ToString(), Is.EqualTo("Open"));
    Assert.That(TypeSafeStatus.Cancelled.ToString(), Is.EqualTo("Cancelled"));
  }
  
  [Test]
  public void Test_05_AllItems()
  {
    Assert.That(TypeSafeStatus.AllItems.SequenceEqual(new[] { TypeSafeStatus.New, TypeSafeStatus.Open, TypeSafeStatus.Cancelled }), Is.True);
  }
  
    
  [Test]
  public void Test_06_TypeConverter()
  {
    var converter = TypeDescriptor.GetConverter(typeof(TypeSafeStatus));
    Assert.That(converter.CanConvertFrom(null, typeof(string)), Is.True);
    Assert.That(converter.ConvertFrom(null, null, "New"), Is.EqualTo(TypeSafeStatus.New));
  }
}