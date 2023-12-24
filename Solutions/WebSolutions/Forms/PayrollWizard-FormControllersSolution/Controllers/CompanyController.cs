using EFPayroll;
using Microsoft.AspNetCore.Mvc;

namespace PayrollWizard.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IPayrollService svc = new PayrollService();
        public IActionResult Index()
        {
            ViewBag.companies = svc.GetCompanies();
            return View();
        }
        public IActionResult Detail(int id)
        {
            (ViewBag.id, ViewBag.taxId, ViewBag.name, ViewBag.address) = svc.GetCompanyDetail(id);
            return View();
        }
        public IActionResult SaveDetail(int id, string taxid, string name, string address)
        {
            svc.SaveCompany(id, taxid, name, address);
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
