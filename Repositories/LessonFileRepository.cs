using FirstProjectApp.Data;
using FirstProjectApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectApp.Repositories
{
    public class LessonFileRepository
    {
        private readonly AppDbContext _context;

        public LessonFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LessonFile>> GetAllAsync() =>
            await _context.LessonFiles.Include(f => f.Lesson).Include(f => f.UploadedBy).ToListAsync();

        public async Task<LessonFile?> GetByIdAsync(int id) =>
            await _context.LessonFiles.Include(f => f.Lesson).Include(f => f.UploadedBy).FirstOrDefaultAsync(f => f.Id == id);

        public async Task AddAsync(LessonFile file)
        {
            _context.LessonFiles.Add(file);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LessonFile file)
        {
            _context.LessonFiles.Update(file);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var file = await _context.LessonFiles.FindAsync(id);
            if (file != null)
            {
                _context.LessonFiles.Remove(file);
                await _context.SaveChangesAsync();
            }
        }
    }

}
