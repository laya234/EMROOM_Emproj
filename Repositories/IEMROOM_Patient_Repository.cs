using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public interface IEMROOM_Patient_Repository
{
    Task<IEnumerable<EMROOM_Patient>> GetAllAsync();
    Task<EMROOM_Patient?> GetByIdAsync(int id);
    Task<EMROOM_Patient> AddAsync(EMROOM_Patient patient);
    Task<EMROOM_Patient> UpdateAsync(EMROOM_Patient patient);
    Task<bool> DeleteAsync(int id);
}