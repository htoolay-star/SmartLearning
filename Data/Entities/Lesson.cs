namespace FirstProjectApp.Data.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<LessonFile> Files { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
