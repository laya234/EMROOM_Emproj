using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Data;
using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public class EMROOM_Emergency_Repository : IEMROOM_Emergency_Repository
{
    private readonly EMROOM_DbContext _context;
    
    public EMROOM_Emergency_Repository(EMROOM_DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EMROOM_Emergency_Case>> GetAllAsync()
    {
        return await _context.EMROOM_Emergency_Cases
            .Include(ec => ec.EMROOM_Patient)
            .Include(ec => ec.EMROOM_Triage_Level)
            .ToListAsync();
    }
    
    public async Task<EMROOM_Emergency_Case?> GetByIdAsync(int id)
    {
        return await _context.EMROOM_Emergency_Cases
            .Include(ec => ec.EMROOM_Patient)
            .Include(ec => ec.EMROOM_Triage_Level)
            .Include(ec => ec.EMROOM_Treatment)
            .FirstOrDefaultAsync(ec => ec.EMROOM_Case_Id == id);
    }
    
    public async Task<IEnumerable<EMROOM_Emergency_Case>> GetByStatusAsync(string status)
    {
        return await _context.EMROOM_Emergency_Cases
            .Include(ec => ec.EMROOM_Patient)
            .Include(ec => ec.EMROOM_Triage_Level)
            .Where(ec => ec.EMROOM_Status == status)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<EMROOM_Emergency_Case>> GetPrioritizedCasesAsync()
    {
        return await _context.EMROOM_Emergency_Cases
            .Include(ec => ec.EMROOM_Patient)
            .Include(ec => ec.EMROOM_Triage_Level)
            .Where(ec => ec.EMROOM_Status == "Waiting")
            .OrderByDescending(ec => ec.EMROOM_Triage_Level.EMROOM_Priority_Score)
            .ThenBy(ec => ec.EMROOM_Arrival_Time)
            .ToListAsync();
    }
    
    public async Task<EMROOM_Emergency_Case> AddAsync(EMROOM_Emergency_Case emergencyCase)
    {
        _context.EMROOM_Emergency_Cases.Add(emergencyCase);
        await _context.SaveChangesAsync();
        return emergencyCase;
    }
    
    public async Task<EMROOM_Emergency_Case> UpdateAsync(EMROOM_Emergency_Case emergencyCase)
    {
        _context.EMROOM_Emergency_Cases.Update(emergencyCase);
        await _context.SaveChangesAsync();
        return emergencyCase;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var emergencyCase = await _context.EMROOM_Emergency_Cases.FindAsync(id);
        if (emergencyCase == null) return false;
        
        _context.EMROOM_Emergency_Cases.Remove(emergencyCase);
        await _context.SaveChangesAsync();
        return true;
    }
}