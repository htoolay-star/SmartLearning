using Microsoft.Extensions.Hosting;

namespace FirstProjectApp.Data.Entities
{
    public class Course : BaseEntity
    {
        public int Id { get; set; }

        public byte[]? ProfileImage { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<AppUserCourse> Enrollments { get; set; }
    }
}
