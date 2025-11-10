using Microsoft.AspNetCore.Identity;

namespace FirstProjectApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        // Profile
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[]? ProfileImage { get; set; }
        public string? InviteToken { get; set; }
        public bool IsInvited { get; set; }
        public DateTime? InvitedAt { get; set; }

        // Advisor relationship (optional)
        public string? AdvisorId { get; set; }
        public AppUser? Advisor { get; set; }

        // Navigation properties
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<AppUserCourse> Enrollments { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        public ICollection<LessonFile> UploadedFiles { get; set; }


        // Social features
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

        // Homework
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }

        // Messaging (optional)
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
