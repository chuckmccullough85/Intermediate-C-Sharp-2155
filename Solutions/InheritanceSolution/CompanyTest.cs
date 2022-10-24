

using Moq;

namespace EFPayroll
{
    public class CompanyTest
    {
        Company company;
        Mock<HumanResource> m1;
        Mock<HumanResource> m2;
        Mock<HumanResource> m3;  

        public CompanyTest()
        {
            company = new("TestCo", "12-34567");
            m1 = new Mock<HumanResource>("Hank", "Hill", DateTime.Today);
            m2 = new Mock<HumanResource>("Peggy", "Hill", DateTime.Today);
            m3 = new Mock<HumanResource>("Bobby", "Hill", DateTime.Today);
            company.Hire(m1.Object);
            company.Hire(m2.Object);
            company.Hire(m3.Object);  
        }
        [Fact]
        public void TestCompanyHire()
        {

            Assert.Equal(3, company.Employees.Size);
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
