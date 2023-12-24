using EFPayroll;
using Microsoft.AspNetCore.Mvc;
using PayrollWizard.Models;

namespace PayrollWizard.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IPayrollService svc = new PayrollService();
        public IActionResult Index()
        {
            var model = svc.GetCompanies();
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var m = svc.GetCompanyDetail(id);
            var model = new CompanyModel(m.id, m.name, m.taxId, m.address);
            return View(model);
        }
        public IActionResult SaveDetail(CompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Detail", model);
            }
            svc.SaveCompany(model.Id, model.TaxId,model.Name, model.Address);
            return RedirectToAction("Index");
        }

        public IActionResult ManageResources()
        {
            return View();
        }
        public IActionResult Hire()
        {
            return View("ManageResources");
        }
        public IActionResult Terminate()
        {
            return View("ManageResources");
        }
    }
}
