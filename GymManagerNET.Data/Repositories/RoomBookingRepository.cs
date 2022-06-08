using GymManagerNET.Core.Models;
using GymManagerNET.Core.Services.RoomBookings;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories;

public class RoomBookingRepository : IRoomBookingRepository
{
    private readonly ApplicationDbContext _context;

    public RoomBookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<RoomBooking>> GetEntities(int id = 0)
    {
        return await _context.RoomBookings.ToListAsync();
    }

    public async Task<RoomBooking> Add(RoomBooking entity)
    {
        await _context.AddAsync(entity);

        return await Commit(entity);
    }

    public async Task<RoomBooking> GetById(int id)
    {
        return await _context?.RoomBookings?.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<RoomBooking> UpdateAsync(RoomBooking updatedEntity)
    {
        _context.RoomBookings.Update(updatedEntity);

        return await Commit(updatedEntity);
    }

    public async Task<RoomBooking> Delete(int id)
    {
        var entity = await GetById(id);

        if (entity != null)
        {
            _context.RoomBookings.Remove(entity);
        }

        return await Commit(entity);
    }
    private async Task<RoomBooking> Commit(RoomBooking entity)
    {
        var commit = await _context.SaveChangesAsync();

        return commit > 0 ? entity : null;
    }

    public async Task<IEnumerable<RoomBooking>> GetEntitiesByRoomId(int id = 0)
    {
        return id == 0
            ? await _context.RoomBookings.ToListAsync()
            : await _context.RoomBookings.Where(x => x.RoomId == id).ToListAsync();
    }

    public async Task<IEnumerable<RoomBooking>> GetEntitiesByActivityId(int id = 0)
    {
        return id == 0
            ? await _context.RoomBookings.ToListAsync()
            : await _context.RoomBookings.Where(x => x.ActivityId == id).ToListAsync();
    }
}