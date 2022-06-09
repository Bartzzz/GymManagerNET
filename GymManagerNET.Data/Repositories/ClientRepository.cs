using GymManagerNET.Core.Models.Users;
using GymManagerNET.Core.Services.Client;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories;
public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Client> Add(Client client)
    {
       await _context.AddAsync(client);

        return await Commit(client);
    }

    public async Task<Client> Delete(int userId)
    {
        var client = await GetById(userId);

        if (client != null)
        {
            _context.Clients.Remove(client);
        }

        return await Commit(client);
    }

    public async Task<Client> GetById(int id)
    {
        return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Client>> GetEntities(int id = 0)
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> UpdateAsync(Client client)
    {
        _context.Clients.Update(client);

        return await Commit(client);
    }

    private async Task<Client> Commit(Client client)
    {
        var commit = await _context.SaveChangesAsync();

        return commit > 0 ? client : null;
    }
}

