using EMROOM_emproj.Models;
using EMROOM_emproj.Repositories;

namespace EMROOM_emproj.Services;

public class EMROOM_Patient_Service : IEMROOM_Patient_Service
{
    private readonly IEMROOM_Patient_Repository _patientRepository;
    
    public EMROOM_Patient_Service(IEMROOM_Patient_Repository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public async Task<IEnumerable<EMROOM_Patient>> GetAllPatientsAsync()
    {
        return await _patientRepository.GetAllAsync();
    }
    
    public async Task<EMROOM_Patient?> GetPatientByIdAsync(int id)
    {
        return await _patientRepository.GetByIdAsync(id);
    }
    
    public async Task<EMROOM_Patient> RegisterPatientAsync(EMROOM_Patient patient)
    {
        patient.EMROOM_Created_At = DateTime.UtcNow;
        return await _patientRepository.AddAsync(patient);
    }
    
    public async Task<EMROOM_Patient> UpdatePatientAsync(EMROOM_Patient patient)
    {
        return await _patientRepository.UpdateAsync(patient);
    }
    
    public async Task<bool> DeletePatientAsync(int id)
    {
        return await _patientRepository.DeleteAsync(id);
    }
}