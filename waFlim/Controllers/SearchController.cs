using Microsoft.AspNetCore.Mvc;

namespace waFlim.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
