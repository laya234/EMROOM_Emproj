using EMROOM_emproj.Models;

namespace EMROOM_emproj.Strategies;

public interface IEMROOM_Triage_Strategy
{
    int CalculatePriority(EMROOM_Emergency_Case emergencyCase);
    string DetermineTriageLevel(string symptoms, int age);
}