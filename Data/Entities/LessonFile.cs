namespace FirstProjectApp.Data.Entities
{
    public class LessonFile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;

        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public DateTime UploadedAt { get; set; }
        public string UploadedById { get; set; } = string.Empty;
        public AppUser? UploadedBy { get; set; }
    }

}
