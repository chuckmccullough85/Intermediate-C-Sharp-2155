

namespace EFPayroll;

public class PayrollService : IPayrollService
{
    private PayDbContext ctx = new();
    public IEnumerable<IdNamePair> GetCompanies() 
        => ctx.Companies.Select(c => new IdNamePair(c.Id, c.Name)).ToList();

    public (int id, string taxId, string name, string address) GetCompanyDetail(int id)
    {
        var c = ctx.Companies.Find(id);
        if (c == null) throw new Exception("Company not found");
        return (c.Id, c.TaxId, c.Name, c.Address);
    }

    public void SaveCompany(int id, string taxid, string name, string address)
    {
        var c = ctx.Companies.Find(id);
        if (c == null) throw new Exception("Company not found");
        c.TaxId = taxid;
        c.Name = name;
        c.Address = address;
        ctx.SaveChanges();
    }
}
