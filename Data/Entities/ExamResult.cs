namespace FirstProjectApp.Data.Entities
{
    public class ExamResult
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public double Score { get; set; }
    }
}
