using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface IWorkerRepository
    {
        Task<Worker> GetAsync(int workerId);
        Task<Worker> GetWithSubordinatesAsync(int workerId);
        Task<bool> AddAsync(Worker worker);
        Task<bool> RemoveAsync(int workerId);
        Task<bool> SaveChangesAsync();
    }
}
