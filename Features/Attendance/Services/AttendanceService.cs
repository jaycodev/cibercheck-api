using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Data;
using CiberCheck.Interfaces;
using CiberCheck.Features.Attendance.Entities;

namespace CiberCheck.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ApplicationDbContext _db;

        public AttendanceService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Attendance>> GetAllAsync()
            => await _db.Attendances.AsNoTracking().ToListAsync();

        public async Task<Attendance?> GetByIdAsync(int studentId, int sessionId)
            => await _db.Attendances.FindAsync(studentId, sessionId);

        public async Task<Attendance> CreateAsync(Attendance entity)
        {
            _db.Attendances.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int studentId, int sessionId, Attendance entity)
        {
            var exists = await _db.Attendances.AnyAsync(e => e.StudentId == studentId && e.SessionId == sessionId);
            if (!exists) return false;
            entity.StudentId = studentId;
            entity.SessionId = sessionId;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int studentId, int sessionId)
        {
            var entity = await _db.Attendances.FindAsync(studentId, sessionId);
            if (entity == null) return false;
            _db.Attendances.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
