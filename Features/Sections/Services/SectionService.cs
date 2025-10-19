using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Data;
using CiberCheck.Interfaces;
using CiberCheck.Features.Sections.Entities;

namespace CiberCheck.Services
{
    public class SectionService : ISectionService
    {
        private readonly ApplicationDbContext _db;

        public SectionService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Section>> GetAllAsync()
            => await _db.Sections.AsNoTracking().ToListAsync();

        public async Task<Section?> GetByIdAsync(int id)
            => await _db.Sections.FindAsync(id);

        public async Task<Section> CreateAsync(Section entity)
        {
            _db.Sections.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, Section entity)
        {
            var exists = await _db.Sections.AnyAsync(e => e.SectionId == id);
            if (!exists) return false;
            entity.SectionId = id;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Sections.FindAsync(id);
            if (entity == null) return false;
            _db.Sections.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
