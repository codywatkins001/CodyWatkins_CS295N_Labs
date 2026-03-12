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
            //check if the submitted model is valid
            if (ModelState.IsValid)
            {
                //set the date
                model.Date = DateOnly.FromDateTime(DateTime.Now);
                //add to DB
                context.Messages.Add(model);
                context.SaveChanges();
                return RedirectToAction("Message");
            }
            //if validation failed, return the same view so errors show
            return View(model);
        }

        public IActionResult Message()
        {
            var messages = context.Messages
                .Include(r => r.To)
                .Include(r => r.From)
                .ToList();
            return View(messages);
        }
        [HttpPost]
        public IActionResult Filter(string to, string date)
        {
            var messages = context.Messages
                .Include(r => r.To)
                .Include(r => r.From)
                .ToList()
                .Where(r => to == null || r.To.Name == to)
                .Where(r => date == null || r.Date == DateOnly.Parse(date))
                .ToList();
            return View("Message", messages);
        }
    }
}
