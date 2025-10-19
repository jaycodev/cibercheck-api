using System.Collections.Generic;
using System.Threading.Tasks;
using CiberCheck.Features.Attendance.Entities;

namespace CiberCheck.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int studentId, int sessionId);
        Task<Attendance> CreateAsync(Attendance entity);
        Task<bool> UpdateAsync(int studentId, int sessionId, Attendance entity);
        Task<bool> DeleteAsync(int studentId, int sessionId);
    }
}
