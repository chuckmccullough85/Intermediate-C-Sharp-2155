
namespace Examples
{

    public class EventUser
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
            example.OnChanged += ShowChanged;
            example.OnChanged += Beeper;
            example.Age = 32;
        }
    }
    public class EventExample
    {
        private int age;
        public delegate void Changed(string property, object oldValue, object newValue);
        public event Changed? OnChanged;
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