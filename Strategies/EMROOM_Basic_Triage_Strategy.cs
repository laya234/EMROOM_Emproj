using EMROOM_emproj.Models;

namespace EMROOM_emproj.Strategies;

public class EMROOM_Basic_Triage_Strategy : IEMROOM_Triage_Strategy
{
    public int CalculatePriority(EMROOM_Emergency_Case emergencyCase)
    {
        var basePriority = emergencyCase.EMROOM_Triage_Level.EMROOM_Priority_Score;
        var waitTime = (DateTime.UtcNow - emergencyCase.EMROOM_Arrival_Time).TotalMinutes;
        
        return basePriority + (int)(waitTime / 10);
    }
    
    public string DetermineTriageLevel(string symptoms, int age)
    {
        var symptomsLower = symptoms.ToLower();
        
        if (symptomsLower.Contains("chest pain") || symptomsLower.Contains("unconscious") || 
            symptomsLower.Contains("severe bleeding") || symptomsLower.Contains("heart attack"))
            return "Critical";
        
        if (symptomsLower.Contains("fracture") || symptomsLower.Contains("high fever") || 
            symptomsLower.Contains("difficulty breathing"))
            return "Urgent";
        
        if (symptomsLower.Contains("moderate pain") || symptomsLower.Contains("infection"))
            return "Semi-Urgent";
        
        return "Non-Urgent";
    }
}