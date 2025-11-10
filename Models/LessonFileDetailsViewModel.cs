namespace FirstProjectApp.Models
{
    public class LessonFileDetailsViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedByName { get; set; }
        public string LessonName { get; set; }
    }

}
