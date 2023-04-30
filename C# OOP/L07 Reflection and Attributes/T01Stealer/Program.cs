using System.Reflection;

//Type types = typeof(Console);

//Console.WriteLine(type.FullName);
//Console.WriteLine(type.Name);
//Console.WriteLine(type.Assembly);
//Console.WriteLine(type.IsArray);
//Console.WriteLine(type.IsAbstract);
//Console.WriteLine(type.IsClass);
//Console.WriteLine(type.IsPublic);


Type type = typeof(Product);

FieldInfo[] fields = type.GetFields(
    BindingFlags.Instance |
    BindingFlags.Public | BindingFlags.NonPublic |
    BindingFlags.Static);

foreach (FieldInfo field in fields)
{
    Console.WriteLine(field.Name);
}

class Product
{
    private int privateField;
    protected int protectedeField;
    internal int internalField;
    public int publicField;

}


