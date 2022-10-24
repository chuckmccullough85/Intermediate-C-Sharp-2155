

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
            company.Add(m1.Object);
            company.Add(m2.Object);
            company.Add(m3.Object);  
        }
        [Fact]
        public void TestCompositeCompany()
        {
            var dept = new Company("MarketingDept", "");
            dept.Add(m1.Object);
            company.Add(dept);
            company.Pay();
            m1.Verify(e => e.Pay(), Times.Exactly(2));
        }
        [Fact]
        public void TestCompanyHire()
        {
            Assert.Equal(3, company.Children.Size);
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
