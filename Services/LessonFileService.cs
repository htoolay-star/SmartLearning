using FirstProjectApp.Data.Entities;
using FirstProjectApp.Repositories;

namespace FirstProjectApp.Services
{
    public class LessonFileService
    {
        private readonly LessonFileRepository _repo;

        public LessonFileService(LessonFileRepository repo)
        {
            _repo = repo;
        }

        public Task<List<LessonFile>> GetAllAsync() => _repo.GetAllAsync();
        public Task<LessonFile?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(LessonFile file) => _repo.AddAsync(file);
        public Task UpdateAsync(LessonFile file) => _repo.UpdateAsync(file);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
