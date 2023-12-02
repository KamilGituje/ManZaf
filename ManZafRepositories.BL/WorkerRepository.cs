using ManZafDatabase;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class WorkerRepository : IWorkerRepository
    {
        public WorkerRepository(PubContext _context)
        {
            context = _context;
        }
        private readonly PubContext context;

        public async Task<Worker> GetAsync(int workerId)
        {
            return await context.Workers.FirstOrDefaultAsync(w => w.WorkerId == workerId);
        }
        public async Task<Worker> GetWithSubordinatesAsync(int workerId)
        {
            return await context.Workers.Include(w => w.Workers).FirstOrDefaultAsync(w => w.WorkerId == workerId);
        }
        public async Task<bool> AddAsync(Worker worker)
        {
            await context.Workers.AddAsync(worker);
            return true;
        }
        public async Task<bool> RemoveAsync(int workerId)
        {
            var worker = await GetWithSubordinatesAsync(workerId);
            if (worker != null)
            {
                context.Remove(worker);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }
    }
}