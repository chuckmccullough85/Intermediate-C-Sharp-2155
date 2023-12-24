using Microsoft.AspNetCore.Mvc;

namespace PayrollWizard_ViewsSolution.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
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
