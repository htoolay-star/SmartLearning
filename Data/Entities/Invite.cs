using Microsoft.Build.Framework;

namespace FirstProjectApp.Data.Entities
{
    public class Invite
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public bool IsUsed { get; set; } = false;
    }
}
