using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Data;
using CiberCheck.Interfaces;
using CiberCheck.Features.Sessions.Entities;

namespace CiberCheck.Services
{
    public class SessionService : ISessionService
    {
        private readonly ApplicationDbContext _db;

        public SessionService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Session>> GetAllAsync()
            => await _db.Sessions.AsNoTracking().ToListAsync();

        public async Task<Session?> GetByIdAsync(int id)
            => await _db.Sessions.FindAsync(id);

        public async Task<Session> CreateAsync(Session entity)
        {
            _db.Sessions.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, Session entity)
        {
            var exists = await _db.Sessions.AnyAsync(e => e.SessionId == id);
            if (!exists) return false;
            entity.SessionId = id;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Sessions.FindAsync(id);
            if (entity == null) return false;
            _db.Sessions.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
