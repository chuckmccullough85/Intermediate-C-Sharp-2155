

namespace EFPayroll
{
    public class ContractorTest
    {
        [Theory]
        [InlineData(50, 2500)]
        [InlineData(40, 2000)]
        public void TestContractorPay(double rate, double pay)
        {
            var c = new Contractor("Hank", "Hill", rate, DateTime.Today);
            Assert.Equal(pay, c.Pay());
        }
    }
}
