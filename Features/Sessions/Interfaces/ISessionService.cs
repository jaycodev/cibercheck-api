using System.Collections.Generic;
using System.Threading.Tasks;
using CiberCheck.Features.Sessions.Entities;

namespace CiberCheck.Interfaces
{
    public interface ISessionService
    {
        Task<List<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task<Session> CreateAsync(Session entity);
        Task<bool> UpdateAsync(int id, Session entity);
        Task<bool> DeleteAsync(int id);
    }
}
