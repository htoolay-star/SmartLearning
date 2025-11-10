using FirstProjectApp.Enums;

namespace FirstProjectApp.Data.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public DayOfWeek Day { get; set; } = DayOfWeek.Monday;

        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
