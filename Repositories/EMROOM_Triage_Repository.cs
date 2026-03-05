using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Data;
using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public class EMROOM_Triage_Repository : IEMROOM_Triage_Repository
{
    private readonly EMROOM_DbContext _context;
    
    public EMROOM_Triage_Repository(EMROOM_DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EMROOM_Triage_Level>> GetAllAsync()
    {
        return await _context.EMROOM_Triage_Levels.ToListAsync();
    }
    
    public async Task<EMROOM_Triage_Level?> GetByIdAsync(int id)
    {
        return await _context.EMROOM_Triage_Levels.FindAsync(id);
    }
    
    public async Task<EMROOM_Triage_Level?> GetByLevelNameAsync(string levelName)
    {
        return await _context.EMROOM_Triage_Levels
            .FirstOrDefaultAsync(tl => tl.EMROOM_Level_Name == levelName);
    }
    
    public async Task<EMROOM_Triage_Level> AddAsync(EMROOM_Triage_Level triageLevel)
    {
        _context.EMROOM_Triage_Levels.Add(triageLevel);
        await _context.SaveChangesAsync();
        return triageLevel;
    }
    
    public async Task<EMROOM_Triage_Level> UpdateAsync(EMROOM_Triage_Level triageLevel)
    {
        _context.EMROOM_Triage_Levels.Update(triageLevel);
        await _context.SaveChangesAsync();
        return triageLevel;
    }
}