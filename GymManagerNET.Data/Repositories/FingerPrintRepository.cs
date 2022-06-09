using GymManagerNET.Core.Models.Users;
using GymManagerNET.Core.Services.Client;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories;

public class FingerPrintRepository : IFingerPrintRepository
{
    private readonly ApplicationDbContext _context;

    public FingerPrintRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<FingerPrint>> GetEntities(int id = 0)
    {
        return await _context.FingerPrint.ToListAsync();
    }

    public async Task<FingerPrint> Add(FingerPrint entity)
    {
        await _context.AddAsync(entity);

        return await Commit(entity);
    }

    public async Task<FingerPrint> GetById(int id)
    {
        return await _context.FingerPrint?.FirstOrDefaultAsync(x => x.UserId == id);
    }

    public async Task<FingerPrint> UpdateAsync(FingerPrint updatedEntity)
    {
        _context.FingerPrint.Update(updatedEntity);

        return await Commit(updatedEntity);
    }

    public async Task<FingerPrint> Delete(int id)
    {
        var entity = await GetById(id);

        if (entity != null)
        {
            _context.FingerPrint.Remove(entity);
        }

        return await Commit(entity);
    }
    private async Task<FingerPrint> Commit(FingerPrint entity)
    {
        var commit = await _context.SaveChangesAsync();

        return commit > 0 ? entity : null;
    }
}