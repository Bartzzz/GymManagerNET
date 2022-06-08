using GymManagerNET.Core.Models;
using GymManagerNET.Core.Services.RoomBookings;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Activity> Add(Activity entity)
    {
        await _context.AddAsync(entity);

        return await Commit(entity);
    }

    public async Task<Activity> Delete(int id)
    {
        var entity = await GetById(id);

        if (entity != null)
        {
            _context.Activities.Remove(entity);
        }

        return await Commit(entity);
    }

    public async Task<Activity> GetById(int id)
    {
        return await _context.Activities?.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Activity>> GetEntities(int id = 0)
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity> UpdateAsync(Activity updatedEntity)
    {
        _context.Activities.Update(updatedEntity);

        return await Commit(updatedEntity);
    }
    private async Task<Activity> Commit(Activity entity)
    {
        var commit = await _context.SaveChangesAsync();

        return commit > 0 ? entity : null;
    }
}