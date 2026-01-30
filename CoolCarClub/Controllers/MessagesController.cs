// Created by Cody Watkins
using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class MessagesController : Controller
    {

        public IActionResult Index()
        {
            var messages = new List<Message>
            {
            new Message
            {
                MessageId = 1,
                Sender = "Cody",
                Recipient = "Alex",
                Subject = "Welcome!",
                Body = "Welcome to the Cool Car Club!",
                Priority = 1,
                DateSent = DateTime.Now,
                IsRead = false
            },
            new Message
            {
                MessageId = 2,
                Sender = "Jamie",
                Recipient = "Everyone",
                Subject = "Car Meet",
                Body = "Car meet this Saturday at noon.",
                Priority = 2,
                DateSent = DateTime.Now.AddHours(-2),
                IsRead = true
            }
        };

            return View(messages);
        }
        public IActionResult Message()
        {
            return View();
        }
    }
}
