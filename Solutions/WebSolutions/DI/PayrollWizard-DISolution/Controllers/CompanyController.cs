using EFPayroll;
using Microsoft.AspNetCore.Mvc;
using PayrollWizard.Models;

namespace PayrollWizard.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IPayrollService svc;
        public CompanyController(IPayrollService svc)
        {
            this.svc = svc;
        }
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
            svc.SaveCompany(model.Id, model.TaxId, model.Name, model.Address);
            return RedirectToAction("Index");
        }

        public IActionResult ManageResources(int id)
        {
            var emps = svc.GetEmployees(id);
            var nonemps = svc.GetNonEmployees(id);
            var model = new ManageResourcesModel(id, svc.GetCompanyName(id), emps, nonemps);
            return View(model);
        }
        public IActionResult Hire(int id, int selectedUnEmployedId)
        {
            svc.Hire(selectedUnEmployedId, id);
            return RedirectToAction("ManageResources", new {id});
        }
        public IActionResult Terminate(int id, int selectedEmployedId)
        {
            svc.Terminate(selectedEmployedId, id);
            return RedirectToAction("ManageResources", new {id});
        }
    }
}
