using EMROOM_emproj.Models;
using EMROOM_emproj.Repositories;

namespace EMROOM_emproj.Services;

public class EMROOM_Emergency_Service : IEMROOM_Emergency_Service
{
    private readonly IEMROOM_Emergency_Repository _emergencyRepository;
    
    public EMROOM_Emergency_Service(IEMROOM_Emergency_Repository emergencyRepository)
    {
        _emergencyRepository = emergencyRepository;
    }
    
    public async Task<IEnumerable<EMROOM_Emergency_Case>> GetAllCasesAsync()
    {
        return await _emergencyRepository.GetAllAsync();
    }
    
    public async Task<EMROOM_Emergency_Case?> GetCaseByIdAsync(int id)
    {
        return await _emergencyRepository.GetByIdAsync(id);
    }
    
    public async Task<IEnumerable<EMROOM_Emergency_Case>> GetPrioritizedCasesAsync()
    {
        return await _emergencyRepository.GetPrioritizedCasesAsync();
    }
    
    public async Task<EMROOM_Emergency_Case> CreateEmergencyCaseAsync(EMROOM_Emergency_Case emergencyCase)
    {
        emergencyCase.EMROOM_Arrival_Time = DateTime.UtcNow;
        emergencyCase.EMROOM_Status = "Waiting";
        return await _emergencyRepository.AddAsync(emergencyCase);
    }
    
    public async Task<EMROOM_Emergency_Case> UpdateCaseStatusAsync(int caseId, string status)
    {
        var emergencyCase = await _emergencyRepository.GetByIdAsync(caseId);
        if (emergencyCase == null)
            throw new Exception($"Emergency case with ID {caseId} not found");
        
        emergencyCase.EMROOM_Status = status;
        return await _emergencyRepository.UpdateAsync(emergencyCase);
    }
    
    public async Task<bool> DeleteCaseAsync(int id)
    {
        return await _emergencyRepository.DeleteAsync(id);
    }
}