namespace TypeSafeEnumApp;

using System.ComponentModel;
using System.Globalization;

[TypeConverter(typeof(TypeSafeStatusConverter))]
public sealed class TypeSafeStatus : TypeSafeEnum<TypeSafeStatus>
{
  public static readonly TypeSafeStatus New = new (TypeSafeStatusId.New, "New");
  public static readonly TypeSafeStatus Open = new (TypeSafeStatusId.Open, "Open");
  public static readonly TypeSafeStatus Cancelled = new (TypeSafeStatusId.Open, "Cancelled");
  
  private TypeSafeStatus(string id, string name) : base(id, name)
  {
  }
}

public static class TypeSafeStatusId
{
  public const string New = "0";
  public const string Open = "1";
  public const string Cancelled = "1";
}

public class TypeSafeStatusConverter : TypeConverter
{
  public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
  {
    return sourceType == typeof(string);
  }

  public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
  {
    var str = (string)value;
    return TypeSafeStatus.Parse(str);
  }
}