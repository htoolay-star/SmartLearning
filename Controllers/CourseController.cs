using FirstProjectApp.Data.Entities;
using FirstProjectApp.Models;
using FirstProjectApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _service.GetAllAsync();
            var vm = courses.Select(c => new CourseListItemViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ProfileImage = c.ProfileImage
            }).ToList();

            return View(vm);
        }


        public IActionResult Create() => View(new CourseFormViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(CourseFormViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            byte[]? imageData = null;
            if (vm.ProfileImageFile != null)
            {
                using var ms = new MemoryStream();
                await vm.ProfileImageFile.CopyToAsync(ms);
                imageData = ms.ToArray();
            }

            var course = new Course
            {
                Name = vm.Name,
                Description = vm.Description,
                ProfileImage = imageData
            };

            await _service.AddAsync(course);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null) return NotFound();

            var vm = new CourseFormViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ExistingImage = course.ProfileImage
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseFormViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            byte[]? imageData = vm.ExistingImage;
            if (vm.ProfileImageFile != null)
            {
                using var ms = new MemoryStream();
                await vm.ProfileImageFile.CopyToAsync(ms);
                imageData = ms.ToArray();
            }

            var course = new Course
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                ProfileImage = imageData
            };

            await _service.UpdateAsync(course);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null) return NotFound();

            var vm = new CourseDetailsViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ProfileImage = course.ProfileImage
            };

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _service.GetByIdAsync(id);
            if (course == null) return NotFound();

            var vm = new CourseDetailsViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ProfileImage = course.ProfileImage
            };

            return View(vm);
        }
    }
}
