using FirstProjectApp.Data.Entities;
using FirstProjectApp.Repositories;

namespace FirstProjectApp.Services
{
    public class CourseService
    {
        private readonly CourseRepository _repo;

        public CourseService(CourseRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Course>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Course?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Course course) => _repo.AddAsync(course);
        public Task UpdateAsync(Course course) => _repo.UpdateAsync(course);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
