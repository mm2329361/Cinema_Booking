using Cinema_Booking.Models;

public interface IUserRepository
{
    Task<Client> GetByEmailAsync(string email);
    Task UpdateAsync(Client client);
    Task AddAsync(Client client);
}