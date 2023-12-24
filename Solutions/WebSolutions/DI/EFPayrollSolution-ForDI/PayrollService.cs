

namespace EFPayroll;

public class PayrollService : IPayrollService
{
    private PayDbContext ctx;
    public PayrollService(PayDbContext ctx) => this.ctx = ctx;
    public IEnumerable<IdNamePair> GetCompanies() 
        => ctx.Companies.Select(c => new IdNamePair(c.Id, c.Name)).ToList();

    public (int id, string taxId, string name, string address) GetCompanyDetail(int id)
    {
        var c = ctx.Companies.Find(id);
        if (c == null) throw new Exception("Company not found");
        return (c.Id, c.TaxId, c.Name, c.Address);
    }

    public string GetCompanyName(int id)
    {
        return ctx.Companies.Find(id)?.Name ?? "";
    }

    public IEnumerable<IdNamePair> GetEmployees(int id)
    {
        return ctx.Companies.Find(id)?.Resources.Select(e => new IdNamePair(e.Id, e.Name)).ToList() ?? new List<IdNamePair>();
    }

    public IEnumerable<IdNamePair> GetNonEmployees(int id)
    {
        var emps = GetEmployees(id);
        var all = ctx.Resources.Select(e => new IdNamePair(e.Id, e.Name)).ToList();
        return all.Except(emps);
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

    public void Hire(int empId, int companyId)
    {
        var c = ctx.Companies.Find(companyId);
        if (c == null) throw new Exception("Company not found");
        var emp = ctx.Resources.Find(empId);
        if (!ReferenceEquals(emp, null))
            c.Resources.Add(emp);
        ctx.SaveChanges();
    }

    public void Terminate(int empId, int companyId)
    {
        var c = ctx.Companies.Find(companyId);
        if (c == null) throw new Exception("Company not found");
        var emp = c.Resources.FirstOrDefault(e => e.Id == empId);
        if (emp != null)
            c.Resources.Remove(emp);
        ctx.SaveChanges();
    }
}
