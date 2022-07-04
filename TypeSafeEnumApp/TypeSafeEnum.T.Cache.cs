namespace TypeSafeEnumApp;

using System.Runtime.CompilerServices;

public abstract partial class TypeSafeEnum<T> where T : TypeSafeEnum<T>
{
  private static class EnumCache
  {
    private static readonly Dictionary<string, T> Map = new(StringComparer.OrdinalIgnoreCase);
    private static readonly List<T> Values = new();

    static EnumCache()
    {
      ////Trigger the static constructor to initialize static members if any
      RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
    }
    
    public static IReadOnlyCollection<T> Items => Values;
      
    public static T Find(string id)
    {
      try
      {
        return Map[id];
      }
      catch (Exception e)
      {
        throw new ArgumentException($"Cannot parse {id} for '{typeof(T)}'");
      }
    }

    public static bool TryFind(string id, out T item)
    {
      item = FindCore(id);
      return item != null;
    }
    
    public static void Add(string id, T item)
    {
      Map.Add(id, item);
      Map.Add(item.Name, item);
      Values.Add(item);
    }

    private static T FindCore(string id)
    {
      return Map.TryGetValue(id, out var itemById) ? itemById : null;
    }
  }
}