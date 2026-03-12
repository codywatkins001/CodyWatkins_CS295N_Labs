//Created by Cody Watkins
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoolCarClub.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required(ErrorMessage = "A recipient is required")]
        public AppUser To { get; set; }

        [Required(ErrorMessage = "A sender is required")]
        public AppUser From { get; set; }

        [Required(ErrorMessage = "Message text is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Message must be between 5 and 500 characters")]
        public string Text { get; set; }
        public DateOnly Date { get; set; }

    }
}
