using FirstProjectApp.Data.Entities;
using FirstProjectApp.Repositories;

namespace FirstProjectApp.Services
{
    public class LessonService
    {
        private readonly LessonRepository _repo;

        public LessonService(LessonRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Lesson>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Lesson?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Lesson lesson) => _repo.AddAsync(lesson);
        public Task UpdateAsync(Lesson lesson) => _repo.UpdateAsync(lesson);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

}
