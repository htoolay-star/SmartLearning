namespace FirstProjectApp.Data.Entities
{
    public class HomeworkSubmission
    {
        public int Id { get; set; }
        public string? AnswerText { get; set; }
        public string? FilePath { get; set; }
        public DateTime SubmittedAt { get; set; }

        public int HomeworkId { get; set; }
        public Homework Homework { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
