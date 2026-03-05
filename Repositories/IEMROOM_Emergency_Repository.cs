using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public interface IEMROOM_Emergency_Repository
{
    Task<IEnumerable<EMROOM_Emergency_Case>> GetAllAsync();
    Task<EMROOM_Emergency_Case?> GetByIdAsync(int id);
    Task<IEnumerable<EMROOM_Emergency_Case>> GetByStatusAsync(string status);
    Task<IEnumerable<EMROOM_Emergency_Case>> GetPrioritizedCasesAsync();
    Task<EMROOM_Emergency_Case> AddAsync(EMROOM_Emergency_Case emergencyCase);
    Task<EMROOM_Emergency_Case> UpdateAsync(EMROOM_Emergency_Case emergencyCase);
    Task<bool> DeleteAsync(int id);
}