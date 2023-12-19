using System.ComponentModel.DataAnnotations;

namespace PayWizWeb.Models;

public record IdValue(int Id, string Value);

public record CompanyDetail(int Id,
    [RegularExpression(@"[\w\s'-]{1,30}")]
    string Name,
    [RegularExpression(@"[\w\s'-]{1,30}")]
    string Address,
    [RegularExpression(@"\d\d\d-\d\d-\d{4}")]
    [property:Display(Name = "Tax ID", Prompt = "123-45-6789")]
    string TaxId);