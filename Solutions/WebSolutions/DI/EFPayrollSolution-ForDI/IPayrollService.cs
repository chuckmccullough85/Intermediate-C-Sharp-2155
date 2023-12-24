
namespace EFPayroll;

public record IdNamePair(int Id, string Name);
public interface IPayrollService
{
    IEnumerable<IdNamePair> GetCompanies();
    (int id, string taxId, string name, string address) GetCompanyDetail(int id);
    string GetCompanyName(int id);
    IEnumerable<IdNamePair> GetEmployees(int id);
    IEnumerable<IdNamePair> GetNonEmployees(int id);
    void Hire(int empId, int companyId);
    void SaveCompany(int id, string taxid, string name, string address);
    void Terminate(int empId, int companyId);
}
