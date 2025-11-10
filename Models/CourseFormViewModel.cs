using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectApp.Models
{
    public class CourseFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? ProfileImageFile { get; set; } // for upload
        public byte[]? ExistingImage { get; set; } // for edit preview
    }
}
