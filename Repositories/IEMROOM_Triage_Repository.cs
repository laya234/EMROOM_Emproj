using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public interface IEMROOM_Triage_Repository
{
    Task<IEnumerable<EMROOM_Triage_Level>> GetAllAsync();
    Task<EMROOM_Triage_Level?> GetByIdAsync(int id);
    Task<EMROOM_Triage_Level?> GetByLevelNameAsync(string levelName);
    Task<EMROOM_Triage_Level> AddAsync(EMROOM_Triage_Level triageLevel);
    Task<EMROOM_Triage_Level> UpdateAsync(EMROOM_Triage_Level triageLevel);
}