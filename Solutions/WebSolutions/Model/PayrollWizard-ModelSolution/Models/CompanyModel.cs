using System.ComponentModel.DataAnnotations;

namespace PayrollWizard.Models;

public record CompanyModel(
    int Id, 
    string Name,
    [RegularExpression(@"^\d{2}-\d{5}$", ErrorMessage ="invalid format")]
    [property:Display(Name = "Tax ID", Prompt ="xx-xxxxx")]
    string TaxId, 
    string Address);
