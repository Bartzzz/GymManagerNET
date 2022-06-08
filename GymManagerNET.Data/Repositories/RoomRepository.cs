using GymManagerNET.Core.Models;
using GymManagerNET.Core.Services.RoomBookings;
using Microsoft.EntityFrameworkCore;

namespace GymManagerNET.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<FitnessRoom> Add(FitnessRoom entity)
        {
            await _context.AddAsync(entity);

            return await Commit(entity);
        }

        public async Task<FitnessRoom> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _context.FitnessRooms.Remove(entity);
            }

            return await Commit(entity);
        }

        public async Task<FitnessRoom> GetById(int id)
        {
            return await _context.FitnessRooms?.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<FitnessRoom>> GetEntities(int id = 0)
        {
            return await _context.FitnessRooms.ToListAsync();
        }

        public async Task<FitnessRoom> UpdateAsync(FitnessRoom updatedEntity)
        {
            _context.FitnessRooms.Update(updatedEntity);

            return await Commit(updatedEntity);
        }

        private async Task<FitnessRoom> Commit(FitnessRoom entity)
        {
            var commit = await _context.SaveChangesAsync();

            return commit > 0 ? entity : null;
        }
    }
}
