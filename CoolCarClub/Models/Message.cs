namespace CoolCarClub.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Sender { get; set; }
        public string Recipient { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public int Priority { get; set; }
        public DateTime DateSent { get; set; }

        public bool IsRead { get; set; }
    }
}
