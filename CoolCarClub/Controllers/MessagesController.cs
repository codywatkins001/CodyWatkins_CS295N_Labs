// Created by Cody Watkins
using CoolCarClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Controllers
{
    public class MessagesController : Controller
    {
        // Fake database (persists while app is running)
        private static List<Message> _messages = new List<Message>
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

        // Show all messages
        public IActionResult Index()
        {
            return View(_messages);
        }

        // SHOW the send message form
        public IActionResult Create()
        {
            return View();
        }

        // HANDLE the form submission
        [HttpPost]
        public IActionResult Create(Message message)
        {
            message.MessageId = _messages.Count + 1;
            message.DateSent = DateTime.Now;
            message.IsRead = false;

            _messages.Add(message);

            return RedirectToAction("Index");
        }
    }
}
