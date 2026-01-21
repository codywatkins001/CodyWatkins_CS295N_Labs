// Created by Cody Watkins
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }
    }
}
