

using EFPayroll;

namespace EFPayroll
{
    public class CompanyDbTest : IDisposable
    {
        PayDbContext ctx;
        public CompanyDbTest()
        {
            ctx = new PayDbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            Seed(ctx);
        }
        [Fact]
        public void TestGetAllCompanies()
        {
            var c = ctx.Companies.First();
            Assert.Equal(3, c.Resources.Count());
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
        static void Seed(PayDbContext ctx)
        {
            Company c1 = new Company("Acme", "12-3456");
            Employee e1 = new Employee("Hank", "Hill", 200, DateTime.Today.AddYears(-10));
            Contractor ctr = new Contractor("Peggy", "Hill", 50, DateTime.Parse("2005-10-31"));
            Intern intern = new Intern("Luann", "Platter", DateTime.Today.AddMonths(-18));
            c1.Hire(e1);
            c1.Hire(ctr);
            c1.Hire(intern);
            ctx.Companies.Add(c1);
            ctx.SaveChanges();
        }
    }
}
