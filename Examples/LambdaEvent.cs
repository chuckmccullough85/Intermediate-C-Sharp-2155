
namespace Examples
{
    public class LambdaEvent
    {
        static void ShowChanged(string property, object oldValue, object newValue)
        {
            Console.WriteLine($"Property {property} changed from {oldValue} to {newValue}");
        }
        static void Beeper(string property, object oldValue, object newValue)
        {
            Console.Beep();
        }
        static void Example()
        {
            EventExample example = new EventExample();
            example.OnChanged += (p,o,n)=> Console.WriteLine($"Property {p} changed from {o} to {n}"); ;
            example.OnChanged += (p,o,n)=>Console.Beep();
            example.Age = 32;
        }
    }
}