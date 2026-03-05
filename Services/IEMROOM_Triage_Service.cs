using EMROOM_emproj.Models;

namespace EMROOM_emproj.Services;

public interface IEMROOM_Triage_Service
{
    Task<IEnumerable<EMROOM_Triage_Level>> GetAllTriageLevelsAsync();
    Task<EMROOM_Triage_Level?> GetTriageLevelByIdAsync(int id);
    Task<string> DetermineTriageLevelAsync(string symptoms, int age, string strategyType);
    Task<int> CalculatePriorityAsync(EMROOM_Emergency_Case emergencyCase, string strategyType);
}