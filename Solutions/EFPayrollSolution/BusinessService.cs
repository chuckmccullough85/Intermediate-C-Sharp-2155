
using EFPayroll;
using System.Runtime.CompilerServices;

namespace EFPayrollSolution;

public record IdName(int Id, string Name);

public class BusinessService
{
    private PayDbContext ctx;

    public BusinessService(PayDbContext _ctx)
    {
        ctx = _ctx;
    }

    public async Task<IEnumerable<IdName>> GetAllCompanies()
    {
        return await Task.Run(()=> ctx.Companies.Select(c => new IdName(c.Id, c.Name)).ToList());
    }

    public (int Id, string Name, string Address, string TaxId) GetCompanyDetail(int id)
    {
        var c = ctx.Companies.Find(id);
        return (c.Id, c.Name, "", c.TaxId);
    }

    public async Task SaveCompany(int id, string name, string address, string taxId)
    {
        var c = ctx.Companies.Find(id);
        if (c == null)
        {
            c = new Company(name, taxId);
            ctx.Companies.Add(c);
        }
        c.Name = name;
        //        c.Address = address;
        c.TaxId = taxId;
        await ctx.SaveChangesAsync();
    }
}
