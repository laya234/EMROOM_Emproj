using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Data;
using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public class EMROOM_Patient_Repository : IEMROOM_Patient_Repository
{
    private readonly EMROOM_DbContext _context;
    
    public EMROOM_Patient_Repository(EMROOM_DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EMROOM_Patient>> GetAllAsync()
    {
        return await _context.EMROOM_Patients.ToListAsync();
    }
    
    public async Task<EMROOM_Patient?> GetByIdAsync(int id)
    {
        return await _context.EMROOM_Patients
            .Include(p => p.EMROOM_Emergency_Cases)
            .FirstOrDefaultAsync(p => p.EMROOM_Patient_Id == id);
    }
    
    public async Task<EMROOM_Patient> AddAsync(EMROOM_Patient patient)
    {
        _context.EMROOM_Patients.Add(patient);
        await _context.SaveChangesAsync();
        return patient;
    }
    
    public async Task<EMROOM_Patient> UpdateAsync(EMROOM_Patient patient)
    {
        _context.EMROOM_Patients.Update(patient);
        await _context.SaveChangesAsync();
        return patient;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await _context.EMROOM_Patients.FindAsync(id);
        if (patient == null) return false;
        
        _context.EMROOM_Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }
}