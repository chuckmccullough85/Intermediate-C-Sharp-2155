

using Moq;

namespace EFPayroll
{
    public class CompanyTest
    {
        Company company;
        Mock<IPayable> m1;
        Mock<IPayable> m2;
        Mock<IPayable> m3;  

        public CompanyTest()
        {
            company = new("TestCo", "12-34567");
            m1 = new Mock<IPayable>();
            m2 = new Mock<IPayable>();
            m3 = new Mock<IPayable>();
            company.Hire(m1.Object);
            company.Hire(m2.Object);
            company.Hire(m3.Object);  
        }
        [Fact]
        public void TestCompanyHire()
        {
            Assert.Equal(3, company.Resources.Count());
        }
        [Fact]
        public void TestCompanyPay()
        {
            m1.Setup(e => e.Pay()).Returns(5);
            m2.Setup(e => e.Pay()).Returns(10);
            m3.Setup(e => e.Pay()).Returns(1);
            Assert.Equal(16, company.Pay());
        }
    }
}
