namespace TypeSafeEnumApp;

public abstract partial class TypeSafeEnum<T> : TypeSafeEnum where T : TypeSafeEnum<T>
{
  protected TypeSafeEnum(string name) : this(name, name)
  {
  }

  protected TypeSafeEnum(string id, string name) : base(id, name)
  {
    EnumCache.Add(id, (T)this);
  }
  
  public static T Parse(string id)
  {
    return EnumCache.Find(id);
  }

  public static bool TryParse(string id, out T result)
  {
    return EnumCache.TryFind(id, out result);
  }
  
  public static IReadOnlyCollection<T> AllItems => EnumCache.Items;
}