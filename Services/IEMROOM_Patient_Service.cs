using EMROOM_emproj.Models;

namespace EMROOM_emproj.Services;

public interface IEMROOM_Patient_Service
{
    Task<IEnumerable<EMROOM_Patient>> GetAllPatientsAsync();
    Task<EMROOM_Patient?> GetPatientByIdAsync(int id);
    Task<EMROOM_Patient> RegisterPatientAsync(EMROOM_Patient patient);
    Task<EMROOM_Patient> UpdatePatientAsync(EMROOM_Patient patient);
    Task<bool> DeletePatientAsync(int id);
}