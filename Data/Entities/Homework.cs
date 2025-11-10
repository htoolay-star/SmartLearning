namespace FirstProjectApp.Data.Entities
{
    public class Homework
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public ICollection<HomeworkSubmission> Submissions { get; set; }
    }
}
