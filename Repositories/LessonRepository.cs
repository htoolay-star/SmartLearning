using FirstProjectApp.Data;
using FirstProjectApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectApp.Repositories
{
    public class LessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetAllAsync() =>
            await _context.Lessons.Include(l => l.Course).ToListAsync();

        public async Task<Lesson?> GetByIdAsync(int id) =>
            await _context.Lessons.Include(l => l.Course).FirstOrDefaultAsync(l => l.Id == id);

        public async Task AddAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }
    }

}
