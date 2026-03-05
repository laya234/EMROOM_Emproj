using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public interface IEMROOM_User_Repository
{
    Task<IEnumerable<EMROOM_User>> GetAllAsync();
    Task<EMROOM_User?> GetByIdAsync(int id);
    Task<EMROOM_User?> GetByEmailAsync(string email);
    Task<IEnumerable<EMROOM_User>> GetByRoleAsync(string role);
    Task<EMROOM_User> AddAsync(EMROOM_User user);
    Task<EMROOM_User> UpdateAsync(EMROOM_User user);
}