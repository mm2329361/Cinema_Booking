using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }
    public async Task<Client> GetByEmailAsync(string email)
    {
        return await _context.Clients.FirstOrDefaultAsync(x => x.Email == email);
    }

    

    public async Task AddAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
    }
}