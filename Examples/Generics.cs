
public class MyGeneric<T>
{
    private T item;
    public MyGeneric(T i)
    {
        item = i;
    }
    public T TheItem
    {
        get { return item; }
        set { item = value; }
    }
}
public class Dog { }

public static class GenericsExamples
{
public static T GenericFunc<T>() where T : new()
{
    return new T();
}

    public static void GenericsClient()
    {
        var gencls = new MyGeneric<Dog>(new Dog());
        var s = GenericFunc<Dog>();
    }


} 
