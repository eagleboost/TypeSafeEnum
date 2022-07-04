namespace TypeSafeEnumApp;

public static class EnumParser<T> where T : struct, Enum
{
  private static readonly Dictionary<string, T> StringToEnum;

  static EnumParser()
  {
    StringToEnum = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
    foreach (T value in Enum.GetValues(typeof(T)))
    {
      StringToEnum.Add(value.ToString(), value);
    }
  }

  public static IReadOnlyCollection<T> AllItems => StringToEnum.Values;

  public static T Parse(string value)
  {
    return StringToEnum[value];
  }
  
  public static bool TryParse(string value, out T result)
  {
    return StringToEnum.TryGetValue(value, out result);
  }
}