
namespace Examples
{
    public class NullableExample
    {
        string? myName = null;

        public void Init()
        {
            Example(myName!);
        }

        public void Example(string text)
        {
            Console.WriteLine(text);
        }

        public void Func()
        {
            Console.WriteLine(myName!.Length);
        }
    }
}