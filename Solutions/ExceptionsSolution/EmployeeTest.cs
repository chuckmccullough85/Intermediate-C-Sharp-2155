using ExceptionLab;

namespace xUnitIntroSolution
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
        public void TestEmployeeBadSalary2() 
        {
            try {
                new Employee("Hank", "Hill", -50, DateTime.Today);
                Assert.True(false, "Should have thrown an exception");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        [Fact]
        public void TestEmployeeFutureHire()
        {
            Assert.Throws<ArgumentException>(
                () => new Employee("Hank", "Hill", 100, DateTime.Now.AddDays(2)));
        }

    }
}