using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
