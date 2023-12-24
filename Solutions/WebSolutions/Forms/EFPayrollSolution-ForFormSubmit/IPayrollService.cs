
namespace EFPayroll;

public record IdNamePair(int Id, string Name);
public interface IPayrollService
{
    IEnumerable<IdNamePair> GetCompanies();
    (int id, string taxId, string name, string address) GetCompanyDetail(int id);
    void SaveCompany(int id, string taxid, string name, string address);
}
