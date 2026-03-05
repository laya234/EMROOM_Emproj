using EMROOM_emproj.Models;
using EMROOM_emproj.Repositories;
using EMROOM_emproj.Factories;

namespace EMROOM_emproj.Services;

public class EMROOM_Triage_Service : IEMROOM_Triage_Service
{
    private readonly IEMROOM_Triage_Repository _triageRepository;
    private readonly EMROOM_Triage_Strategy_Factory _strategyFactory;
    
    public EMROOM_Triage_Service(IEMROOM_Triage_Repository triageRepository, EMROOM_Triage_Strategy_Factory strategyFactory)
    {
        _triageRepository = triageRepository;
        _strategyFactory = strategyFactory;
    }
    
    public async Task<IEnumerable<EMROOM_Triage_Level>> GetAllTriageLevelsAsync()
    {
        return await _triageRepository.GetAllAsync();
    }
    
    public async Task<EMROOM_Triage_Level?> GetTriageLevelByIdAsync(int id)
    {
        return await _triageRepository.GetByIdAsync(id);
    }
    
    public async Task<string> DetermineTriageLevelAsync(string symptoms, int age, string strategyType)
    {
        var strategy = _strategyFactory.GetStrategy(strategyType);
        return strategy.DetermineTriageLevel(symptoms, age);
    }
    
    public async Task<int> CalculatePriorityAsync(EMROOM_Emergency_Case emergencyCase, string strategyType)
    {
        var strategy = _strategyFactory.GetStrategy(strategyType);
        return await Task.FromResult(strategy.CalculatePriority(emergencyCase));
    }
}