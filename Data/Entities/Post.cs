using FirstProjectApp.Enums;

namespace FirstProjectApp.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public PostStatus Status { get; set; }

        public string CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
