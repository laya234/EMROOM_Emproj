using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Data;
using EMROOM_emproj.Models;

namespace EMROOM_emproj.Repositories;

public class EMROOM_User_Repository : IEMROOM_User_Repository
{
    private readonly EMROOM_DbContext _context;
    
    public EMROOM_User_Repository(EMROOM_DbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<EMROOM_User>> GetAllAsync()
    {
        return await _context.EMROOM_Users.ToListAsync();
    }
    
    public async Task<EMROOM_User?> GetByIdAsync(int id)
    {
        return await _context.EMROOM_Users.FindAsync(id);
    }
    
    public async Task<EMROOM_User?> GetByEmailAsync(string email)
    {
        return await _context.EMROOM_Users
            .FirstOrDefaultAsync(u => u.EMROOM_Email == email);
    }
    
    public async Task<IEnumerable<EMROOM_User>> GetByRoleAsync(string role)
    {
        return await _context.EMROOM_Users
            .Where(u => u.EMROOM_Role == role)
            .ToListAsync();
    }
    
    public async Task<EMROOM_User> AddAsync(EMROOM_User user)
    {
        _context.EMROOM_Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    public async Task<EMROOM_User> UpdateAsync(EMROOM_User user)
    {
        _context.EMROOM_Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}