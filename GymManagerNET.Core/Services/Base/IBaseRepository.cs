using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerNET.Core.Services.Base
{
    public interface IBaseRepository<T> where T : new()
    {
        Task<IEnumerable<T>> GetEntities(int id = 0);
        Task<T> Add(T entity);
        Task<T> GetById(int id);
        Task<T> UpdateAsync(T updatedEntity);
        Task<T> Delete(int id);
    }
}
