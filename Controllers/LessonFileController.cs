using FirstProjectApp.Data;
using FirstProjectApp.Data.Entities;
using FirstProjectApp.Models;
using FirstProjectApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectApp.Controllers
{
    public class LessonFileController : Controller
    {
        private readonly LessonFileService _service;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public LessonFileController(
            LessonFileService service,
            AppDbContext context,
            UserManager<AppUser> userManager,
            IWebHostEnvironment env)
        {
            _service = service;
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var files = await _service.GetAllAsync();
            var vm = files.Select(f => new LessonFileListItemViewModel
            {
                Id = f.Id,
                FileName = f.FileName,
                FileType = f.FileType,
                LessonName = f.Lesson?.Name ?? "Unknown",
                UploadedAt = f.UploadedAt
            }).ToList();

            return View(vm);
        }

        public IActionResult Create()
        {
            var vm = new LessonFileFormViewModel
            {
                LessonList = _context.Lessons
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonFileFormViewModel vm)
        {
            if (!ModelState.IsValid || vm.Upload == null)
            {
                vm.LessonList = _context.Lessons
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList();
                ModelState.AddModelError("Upload", "File is required.");
                return View(vm);
            }

            var fileName = Path.GetFileName(vm.Upload.FileName);
            var fileType = vm.Upload.ContentType;
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);
            var filePath = Path.Combine(uploadsFolder, Guid.NewGuid() + "_" + fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await vm.Upload.CopyToAsync(stream);

            var user = await _userManager.GetUserAsync(User);

            var file = new LessonFile
            {
                FileName = fileName,
                FileType = fileType,
                FilePath = "/uploads/" + Path.GetFileName(filePath),
                LessonId = vm.LessonId,
                UploadedAt = DateTime.UtcNow,
                UploadedById = user?.Id ?? ""
            };

            await _service.AddAsync(file);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var file = await _service.GetByIdAsync(id);
            if (file == null) return NotFound();

            var vm = new LessonFileFormViewModel
            {
                Id = file.Id,
                FileName = file.FileName,
                FileType = file.FileType,
                LessonId = file.LessonId,
                LessonList = _context.Lessons
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LessonFileFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.LessonList = _context.Lessons
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                    .ToList();
                return View(vm);
            }

            var file = await _service.GetByIdAsync(vm.Id);
            if (file == null) return NotFound();

            file.FileName = vm.FileName;
            file.FileType = vm.FileType;
            file.LessonId = vm.LessonId;

            await _service.UpdateAsync(file);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var file = await _service.GetByIdAsync(id);
            if (file == null) return NotFound();

            var vm = new LessonFileDetailsViewModel
            {
                Id = file.Id,
                FileName = file.FileName,
                FileType = file.FileType,
                FilePath = file.FilePath,
                UploadedAt = file.UploadedAt,
                UploadedByName = file.UploadedBy?.UserName ?? "Unknown",
                LessonName = file.Lesson?.Name ?? "Unknown"
            };

            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var file = await _service.GetByIdAsync(id);
            if (file == null) return NotFound();

            var vm = new LessonFileDetailsViewModel
            {
                Id = file.Id,
                FileName = file.FileName,
                FileType = file.FileType,
                FilePath = file.FilePath,
                UploadedAt = file.UploadedAt,
                UploadedByName = file.UploadedBy?.UserName ?? "Unknown",
                LessonName = file.Lesson?.Name ?? "Unknown"
            };

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}
