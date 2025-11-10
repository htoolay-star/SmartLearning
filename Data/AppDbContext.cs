using FirstProjectApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FirstProjectApp.Models;

namespace FirstProjectApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonFile> LessonFiles { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>()
            .HasOne(p => p.CreatedBy)
            .WithMany()
            .HasForeignKey(p => p.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
            .HasOne(p => p.Course)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
            .HasOne(c => c.AppUser)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reaction>()
            .HasOne(r => r.AppUser)
            .WithMany(u => u.Reactions)
            .HasForeignKey(r => r.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LessonFile>()
            .HasOne(f => f.UploadedBy)
            .WithMany(u => u.UploadedFiles)
            .HasForeignKey(f => f.UploadedById)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Lesson>()
            .HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Homework>()
            .HasOne(h => h.Lesson)
            .WithMany(l => l.Homeworks)
            .HasForeignKey(h => h.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HomeworkSubmission>()
            .HasOne(s => s.Homework)
            .WithMany(h => h.Submissions)
            .HasForeignKey(s => s.HomeworkId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HomeworkSubmission>()
            .HasOne(s => s.AppUser)
            .WithMany(u => u.HomeworkSubmissions)
            .HasForeignKey(s => s.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
            .HasOne(a => a.AppUser)
            .WithMany(u => u.Attendances)
            .HasForeignKey(a => a.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Attendance>()
            .HasOne(a => a.Course)
            .WithMany(c => c.Attendances)
            .HasForeignKey(a => a.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);

            builder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            // Advisor (self-referencing)
            builder.Entity<AppUser>()
                .HasOne(u => u.Advisor)
                .WithMany()
                .HasForeignKey(u => u.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUserCourse (many-to-many)
            builder.Entity<AppUserCourse>()
                .HasOne(e => e.AppUser)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.AppUserId);

            builder.Entity<AppUserCourse>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Message (Sender → Receiver)
            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // ExamResult → Exam and AppUser
            builder.Entity<ExamResult>()
                .HasOne(r => r.Exam)
                .WithMany(e => e.ExamResults)
                .HasForeignKey(r => r.ExamId);

            builder.Entity<ExamResult>()
                .HasOne(r => r.AppUser)
                .WithMany(u => u.ExamResults)
                .HasForeignKey(r => r.AppUserId);

            // Notification → AppUser
            builder.Entity<Notification>()
                .HasOne(n => n.AppUser)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.AppUserId);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
        public DbSet<FirstProjectApp.Models.CourseListItemViewModel> CourseListItemViewModel { get; set; } = default!;
        public DbSet<FirstProjectApp.Models.CourseFormViewModel> CourseFormViewModel { get; set; } = default!;
        public DbSet<FirstProjectApp.Models.CourseDetailsViewModel> CourseDetailsViewModel { get; set; } = default!;
    }
}
