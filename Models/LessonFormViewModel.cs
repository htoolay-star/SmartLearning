using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FirstProjectApp.Models
{
    public class LessonFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CourseId { get; set; }

        public List<SelectListItem> CourseList { get; set; } = new();
    }

}
