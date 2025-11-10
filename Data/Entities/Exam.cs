namespace FirstProjectApp.Data.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; } = string.Empty;

        public ICollection<ExamResult> ExamResults { get; set; }    
    }
}
