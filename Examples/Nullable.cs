
namespace Examples
{
    public class NullableExample
    {
        string? myName = null;

        public void Init()
        {
            myName = "Hello";
        }

        public void Func()
        {
            Console.WriteLine(myName!.Length);
        }
    }
}