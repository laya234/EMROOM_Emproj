using EMROOM_emproj.Models;

namespace EMROOM_emproj.Strategies;

public class EMROOM_Advanced_Triage_Strategy : IEMROOM_Triage_Strategy
{
    public int CalculatePriority(EMROOM_Emergency_Case emergencyCase)
    {
        var basePriority = emergencyCase.EMROOM_Triage_Level.EMROOM_Priority_Score;
        var waitTime = (DateTime.UtcNow - emergencyCase.EMROOM_Arrival_Time).TotalMinutes;
        var ageMultiplier = emergencyCase.EMROOM_Patient.EMROOM_Age > 65 || emergencyCase.EMROOM_Patient.EMROOM_Age < 5 ? 1.2 : 1.0;
        
        // Calculate symptom-based priority
        var symptomPriority = 0;
        foreach (var caseSymptom in emergencyCase.EMROOM_Case_Symptoms)
        {
            symptomPriority += caseSymptom.EMROOM_Symptom.EMROOM_Base_Severity_Weight * caseSymptom.EMROOM_Severity_Level;
        }
        
        return (int)((basePriority + symptomPriority + (waitTime / 5)) * ageMultiplier);
    }
    
    public string DetermineTriageLevel(string symptoms, int age)
    {
        var symptomsLower = symptoms.ToLower();
        var criticalScore = 0;
        var urgentScore = 0;
        
        if (symptomsLower.Contains("chest pain")) criticalScore += 3;
        if (symptomsLower.Contains("unconscious")) criticalScore += 5;
        if (symptomsLower.Contains("severe bleeding")) criticalScore += 4;
        if (symptomsLower.Contains("heart attack")) criticalScore += 5;
        if (symptomsLower.Contains("stroke")) criticalScore += 5;
        
        if (symptomsLower.Contains("fracture")) urgentScore += 2;
        if (symptomsLower.Contains("high fever")) urgentScore += 2;
        if (symptomsLower.Contains("difficulty breathing")) urgentScore += 3;
        if (symptomsLower.Contains("severe pain")) urgentScore += 2;
        
        if (age > 65 || age < 5)
        {
            criticalScore += 1;
            urgentScore += 1;
        }
        
        if (criticalScore >= 3) return "Critical";
        if (urgentScore >= 2 || criticalScore > 0) return "Urgent";
        if (urgentScore > 0) return "Semi-Urgent";
        
        return "Non-Urgent";
    }
}