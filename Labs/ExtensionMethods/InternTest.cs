
namespace EFPayroll
{
    public class InternTest
    {
        [Fact]
        public void InternPayTest()
        {
            var i = new Intern("Hank", "Hill", DateTime.Today);
            Assert.Equal(50, i.Pay());
        }
    }
}
