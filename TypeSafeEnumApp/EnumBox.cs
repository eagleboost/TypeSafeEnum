namespace TypeSafeEnumApp;

public static class EnumBox<T> where T : struct, Enum
{
  private static readonly Dictionary<T, object> BoxedValues = new();

  static EnumBox()
  {
    foreach (var value in Enum.GetValues(typeof(T)))
    {
      BoxedValues.Add((T)value, value);
    }
  }
  
  public static object Box(T value)
  {
    return BoxedValues[value];
  }
}