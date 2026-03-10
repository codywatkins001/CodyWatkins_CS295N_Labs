// Created by Cody Watkins
using CoolCarClub.Data;
using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolCarClub.Controllers
{
    public class MessagesController : Controller
    {
        CoolCarClubDbContext context;
        //constructor
        public MessagesController(CoolCarClubDbContext c)
        {
            context = c;
        }
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
            context.Messages.Add(model);
            context.SaveChanges();
            return View("Message", model);
        }

        public IActionResult Message(Message model)
        {
            var messages = context.Messages
                .Include(r => r.To)
                .Include(r => r.From)
                .ToList();
            return View(messages);
        }
    }
}
