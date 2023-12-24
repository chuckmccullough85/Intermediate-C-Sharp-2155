

namespace EFPayroll;

public class PayrollService : IPayrollService
{
    private PayDbContext ctx = new();
    public IEnumerable<IdNamePair> GetCompanies() 
        => ctx.Companies.Select(c => new IdNamePair(c.Id, c.Name)).ToList();
}
