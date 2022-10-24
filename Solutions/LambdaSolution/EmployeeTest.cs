

using Event;
using System.Reflection.Metadata.Ecma335;

namespace EventTest
{
    public class EmployeeTest
    {
        [Fact]
        public void TestTenureProperty()
        {
            var e = new Employee("Hank", "Hill", 100, DateTime.Now.AddYears(-5).AddDays(-10));
            Assert.Equal(5, e.Tenure);
        }

        [Theory]
        [InlineData(6, 100.0, 94.2)]
        [InlineData(0, 100.0, 92.35)]
        [InlineData(3, 200.0, 184.7)]
        public void TestPay(int tenure, double sal, double pay)
        {
            var e = new Employee("Hank", "Hill", sal, DateTime.Now.AddYears(-tenure));
            Assert.Equal(pay, e.Pay(), 2);
        }
        [Fact]
        public void NullLocalTaxTest()
        {
            var e = new Employee("Hank", "Hill", 100, DateTime.Now.AddYears(-5).AddDays(-10));
            e.LocalTaxMethod = null;
            e.Pay();
        }

        [Fact]
        public void LocalTaxCalledTest()
        {
            var e = new Employee("Hank", "Hill", 100, DateTime.Now.AddYears(-5).AddDays(-10));
            bool called = false;
            e.LocalTaxMethod = (amt) => { called = true; return 10; };
            e.Pay();
            Assert.True(called);
        }
        [Fact]
        public void LocalTaxAddedTest()
        {
            var e = new Employee("Hank", "Hill", 100, DateTime.Now.AddYears(-5).AddDays(-10));
            var nt = e.Pay();
            e.LocalTaxMethod = (amt) => 10;
            Assert.Equal(nt - 10, e.Pay(), 2);
        }

        [Fact]
        public void PayEventTest()
        {
            var e = new Employee("Hank", "Hill", 100, DateTime.Now.AddYears(-5).AddDays(-10));
            bool called = false;
            e.OnPay += (emp, amt) => { 
                called = true; 
                Assert.Same(e, emp);
                Assert.True(e.Salary > amt && amt > 0); };
            var nt = e.Pay();
            Assert.True(called);
        }

        private void createbad() { new Employee("Hank", "$$", 200, DateTime.Today); }

        [Fact]
        public void TestEmployeeBadLastName()
        {
            Assert.Throws<ArgumentException>(createbad);
        }

        [Fact]
        public void TestEmployeeBadSalary()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => new Employee("Hank", "Hill", -50, DateTime.Today));
        }
        [Fact]
        public void TestEmployeeFutureHire()
        {
            Assert.Throws<ArgumentException>(
                () => new Employee("Hank", "Hill", 100, DateTime.Now.AddDays(2)));
        }

    }
}