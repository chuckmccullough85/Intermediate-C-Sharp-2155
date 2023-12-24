
namespace EFPayroll;

public record IdNamePair(int Id, string Name);
public interface IPayrollService
{
    IEnumerable<IdNamePair> GetCompanies();
}
