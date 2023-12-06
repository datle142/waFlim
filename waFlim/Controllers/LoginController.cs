using Microsoft.AspNetCore.Mvc;

namespace waFlim.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
