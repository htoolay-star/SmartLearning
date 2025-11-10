namespace FirstProjectApp.Data.Entities
{
    public class AppUserCourse
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrolledDate { get; set; } = DateTime.UtcNow;
    }
}
