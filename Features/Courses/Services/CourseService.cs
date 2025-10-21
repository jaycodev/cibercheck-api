using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Data;
using CiberCheck.Interfaces;
using CiberCheck.Features.Courses.Entities;
using System.Linq;

namespace CiberCheck.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _db;

        public CourseService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Course>> GetAllAsync()
            => await _db.Courses.AsNoTracking().ToListAsync();

        public async Task<Course?> GetByIdAsync(int id)
            => await _db.Courses.FindAsync(id);

        public async Task<Course> CreateAsync(Course entity)
        {
            _db.Courses.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, Course entity)
        {
            var exists = await _db.Courses.AnyAsync(e => e.CourseId == id);
            if (!exists) return false;
            entity.CourseId = id;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Courses.FindAsync(id);
            if (entity == null) return false;
            _db.Courses.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetCoursesByTeacherIdAsync(int teacherId)
        {
            return await _db.Courses
                .Include(c => c.Sections)
                .Where(c => c.Sections.Any(s => s.TeacherId == teacherId))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
