using Xunit;

namespace Examples
{
    public class XunitExample
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact] void TestTodayGreaterThanYesterday()
        {
            var today = DateTime.Now;
            var yesterday = today.AddDays(-1);
            Assert.True(today > yesterday);
            Assert.
        }
    }
}