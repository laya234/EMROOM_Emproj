using EMROOM_emproj.Models;

namespace EMROOM_emproj.Services;

public interface IEMROOM_Emergency_Service
{
    Task<IEnumerable<EMROOM_Emergency_Case>> GetAllCasesAsync();
    Task<EMROOM_Emergency_Case?> GetCaseByIdAsync(int id);
    Task<IEnumerable<EMROOM_Emergency_Case>> GetPrioritizedCasesAsync();
    Task<EMROOM_Emergency_Case> CreateEmergencyCaseAsync(EMROOM_Emergency_Case emergencyCase);
    Task<EMROOM_Emergency_Case> UpdateCaseStatusAsync(int caseId, string status);
    Task<bool> DeleteCaseAsync(int id);
}