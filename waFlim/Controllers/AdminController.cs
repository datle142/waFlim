using Microsoft.AspNetCore.Mvc;
using waFlim.Models;

namespace waFlim.Controllers
{
    public class AdminController : Controller
    {
        Models.flimContext db= new Models.flimContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult themfilm(Phim id)
        {
            var phim = db.Phims.SingleOrDefault(x => x.MaPhim == id);
            if (phim != null)
            {
                var phim1 = new Phim()
                {
                    MaPhim = phim.MaPhim,
                    TenPhim = phim.TenPhim,

                };
                return View(phim1);
            }
            return RedirectToAction("Index"); 
        }
    }
}
