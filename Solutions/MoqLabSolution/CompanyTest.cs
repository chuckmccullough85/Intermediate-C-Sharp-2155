

using Moq;

namespace MoqLab
{
    public class CompanyTest
    {
        Company company;
        Mock<IEmployee> m1;
        Mock<IEmployee> m2;
        IEmployee e3;   // to demonstrate mock.of

        public CompanyTest()
        {
            company = new("TestCo", "12-34567");
            m1 = new Mock<IEmployee>();
            m2 = new Mock<IEmployee>();
            e3 = Mock.Of<IEmployee>();
            company.Hire(m1.Object);
            company.Hire(m2.Object);
            company.Hire(e3);        
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
            Mock.Get(e3).Setup(e => e.Pay()).Returns(1);
            Assert.Equal(16, company.Pay());
        }
    }
}
