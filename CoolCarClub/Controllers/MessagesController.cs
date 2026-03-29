// Created by Cody Watkins
using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForumPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForumPost(Message model)
        {
            model.Date = DateOnly.FromDateTime(DateTime.Now);
            return View("Message", model);
        }

        public IActionResult Message(Message model)
        {
            return View(model);
        }
    }
}
