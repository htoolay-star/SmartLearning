using Microsoft.Build.Framework;

namespace FirstProjectApp.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }
        public AppUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;
    }
}
