
namespace EFPayroll;

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
    private static void Seed(PayDbContext ctx)
    {
        Company c1 = new ("Strickland Propane", "12-3456");
        Company c2 = new ("Arlen Public Library", "98-7654");
        Employee e1 = new ("Hank", "Hill", 200, DateTime.Today.AddYears(-10));
        Contractor ctr = new ("Peggy", "Hill", 50, DateTime.Parse("2005-10-31"));
        Intern intern = new ("Luann", "Platter", DateTime.Today.AddMonths(-18));
        c1.Hire(e1);
        c1.Hire(ctr);
        c2.Hire(intern);
        ctx.Companies.Add(c1);
        ctx.Companies.Add(c2);
        ctx.SaveChanges();
    }
}

