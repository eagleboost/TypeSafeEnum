namespace TypeSafeEnumApp;

public class TypeSafeEnum
{
  protected TypeSafeEnum(string id, string name)
  {
    Id = id;
    Name = name;
  }
    
  public readonly string Id;
    
  public readonly string Name;
  
  public override string ToString()
  {
    return Name;
  }
}