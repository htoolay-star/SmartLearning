using FirstProjectApp.Enums;

namespace FirstProjectApp.Data.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public ReactionType Type { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TargetId { get; set; }
        public ReactionTargetType TargetType { get; set; }
    }
}
