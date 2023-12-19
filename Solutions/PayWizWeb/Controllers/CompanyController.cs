using EFPayrollSolution;
using Microsoft.AspNetCore.Mvc;
using PayWizWeb.Models;

namespace PayWizWeb.Controllers;

public class CompanyController : Controller
{
    BusinessService svc;
    public CompanyController(BusinessService _svc)
    {
        svc = _svc;
    }

    public async Task<IActionResult> Index()
    {
        var companies = await svc.GetAllCompanies();
        var model = companies.Select(c => new IdValue(c.Id, c.Name));
        ViewBag.Companies = model;
        return View();
    }

    public IActionResult Detail(int id)
    {
        var detail = svc.GetCompanyDetail(id);
        var company = new CompanyDetail(id, detail.Name, detail.Address, detail.TaxId);
        return View(company);
    }

    [HttpPost]
    public async Task<IActionResult> SaveDetail(CompanyDetail model)
    {
        if (!ModelState.IsValid)
        {
            return View("Detail", model);
        }

        await svc.SaveCompany(model.Id, model.Name, model.Address, model.TaxId);

        return RedirectToAction("Index");
    }
    public IActionResult ManageResources(int id)
    {
        return View();
    }
}
