using System.Diagnostics.Contracts;

namespace Examples
{
    public class Test
    {
        public void Foo (int age)
        {
            Contract.Requires(age < 0 || age > 100);




        }
    }
}
