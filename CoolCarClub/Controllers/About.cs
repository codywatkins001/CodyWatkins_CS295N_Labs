using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
