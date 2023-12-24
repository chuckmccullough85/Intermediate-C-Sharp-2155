using EFPayroll;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PayrollWizard.Models;

public record CompanyModel(
    int Id, 
    string Name,
    [RegularExpression(@"^\d{2}-\d{5}$", ErrorMessage ="invalid format")]
    [property:Display(Name = "Tax ID", Prompt ="xx-xxxxx")]
    string TaxId, 
    string Address);


public class ManageResourcesModel
{
    public ManageResourcesModel()
    {
        EmployedList = new List<SelectListItem>();
        UnEmployedList = new List<SelectListItem>();
        CompanyName = "";
    }
    public ManageResourcesModel(int companyId, string companyName, 
        IEnumerable<IdNamePair> employedList, IEnumerable<IdNamePair> unemployedList)
    {
        CompanyId = companyId;
        CompanyName = companyName;
        EmployedList = employedList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
        UnEmployedList = unemployedList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
    }
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? SelectedEmployedId { get; set; } = "";
    public string? SelectedUnEmployedId { get; set; } = "";
    public IEnumerable<SelectListItem>? EmployedList { get; set; }
    public IEnumerable<SelectListItem>? UnEmployedList { get; set; }
}