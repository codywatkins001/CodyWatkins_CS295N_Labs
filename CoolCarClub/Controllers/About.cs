using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
    }
}
