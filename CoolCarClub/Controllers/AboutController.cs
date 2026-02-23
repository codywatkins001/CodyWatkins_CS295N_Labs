using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
