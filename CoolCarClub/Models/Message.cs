//Created by Cody Watkins
using Microsoft.AspNetCore.Mvc;

namespace CoolCarClub.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public AppUser To { get; set; }
        public AppUser From { get; set; }
        public string Text { get; set; }
        public DateOnly Date { get; set; }

    }
}
