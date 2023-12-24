using EFPayroll;
using Microsoft.AspNetCore.Mvc;

namespace PayrollWizard_ViewsSolution.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IPayrollService svc = new PayrollService();
        public IActionResult Index()
        {
            ViewBag.companies = svc.GetCompanies();
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult SaveDetail()
        {
            return View("Index");
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
