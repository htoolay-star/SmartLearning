using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectApp.Models
{
    public class LessonFileFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileType { get; set; }

        [NotMapped]
        public IFormFile? Upload { get; set; }

        [Required]
        public int LessonId { get; set; }

        public List<SelectListItem> LessonList { get; set; } = new();
    }

}
