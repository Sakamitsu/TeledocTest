using Microsoft.AspNetCore.Mvc;

namespace TeledocTest.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult NotFoundPage()
        {
            return View();
        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
