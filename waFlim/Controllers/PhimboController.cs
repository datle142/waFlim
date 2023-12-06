using Microsoft.AspNetCore.Mvc;

namespace waFlim.Controllers
{
    public class PhimboController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
