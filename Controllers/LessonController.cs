using FirstProjectApp.Data;
using FirstProjectApp.Data.Entities;
using FirstProjectApp.Models;
using FirstProjectApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectApp.Controllers
{
    public class LessonController : Controller
    {
        private readonly LessonService _service;
        private readonly AppDbContext _context;

        public LessonController(LessonService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _service.GetAllAsync();
            var vm = lessons.Select(l => new LessonListItemViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                CourseName = l.Course.Name
            }).ToList();

            return View(vm);
        }

        public IActionResult Create()
        {
            var vm = new LessonFormViewModel
            {
                CourseList = _context.Courses
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CourseList = _context.Courses
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();
                return View(vm);
            }

            var lesson = new Lesson
            {
                Name = vm.Name,
                Description = vm.Description,
                CourseId = vm.CourseId
            };

            await _service.AddAsync(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lesson = await _service.GetByIdAsync(id);
            if (lesson == null) return NotFound();

            var vm = new LessonFormViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                CourseId = lesson.CourseId,
                CourseList = _context.Courses
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LessonFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CourseList = _context.Courses
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();
                return View(vm);
            }

            var lesson = new Lesson
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                CourseId = vm.CourseId
            };

            await _service.UpdateAsync(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _service.GetByIdAsync(id);
            if (lesson == null) return NotFound();

            var vm = new LessonDetailsViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                CourseName = lesson.Course.Name
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
            var lesson = await _service.GetByIdAsync(id);
            if (lesson == null) return NotFound();

            var vm = new LessonDetailsViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                CourseName = lesson.Course.Name
            };

            return View(vm);
        }
    }

}
