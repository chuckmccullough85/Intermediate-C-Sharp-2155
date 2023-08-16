
namespace Examples
{

    public class DelegateUser
    {
        static void ShowChanged(string property, object oldValue, object newValue)
        {
            Console.WriteLine($"Property {property} changed from {oldValue} to {newValue}");
        }
        static void Example()
        {
            DelegateExample example = new DelegateExample();
            example.OnChanged = ShowChanged;
            example.Age = 32;
        }
    }
public class DelegateExample
{
    private int age;
    public delegate void Changed(string property, object oldValue, object newValue);
    public Changed? OnChanged;
    public int Age
    {
        get { return age; }
        set
        {
            var old = age;
            age = value;
            if (old != value)
            {
                OnChanged?.Invoke("Age", old, value);
            }
        }
    }
}
}