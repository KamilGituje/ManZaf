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
    public class SingleLeaveRepository : ISingleLeaveRepository
    {
        public SingleLeaveRepository(PubContext _context)
        {
            context = _context;
        }

        private readonly PubContext context;
        
        public async Task<SingleLeave> GetAsync(int singleLeaveId)
        {
            return await context.SingleLeaves.Include(sl => sl.Worker).Include(sl => sl.LeaveType).FirstOrDefaultAsync(sl => sl.SingleLeaveId == singleLeaveId);
        }
        public async Task<List<SingleLeave>> GetSingleLeavesAsync(int workerId)
        {
            return await context.SingleLeaves.Include(sl => sl.LeaveType).Where(sl => sl.WorkerId == workerId).ToListAsync();
        }
        public async Task<List<SingleLeave>> GetSingleLeavesByManagerIdAsync(int managerId)
        {
            return await context.SingleLeaves.Include(sl => sl.LeaveType).Where(sl => sl.Worker.ManagerId == managerId).ToListAsync();
        }
        public async Task<List<SingleLeave>> GetSingleLeavesUnmanagedByManagerIdAsync(int managerId)
        {
            return await context.SingleLeaves.Include(sl => sl.LeaveType).Include(sl => sl.Worker).Where(sl => sl.Worker.ManagerId == managerId && sl.Status == 0).ToListAsync();
        }
        public async Task<SingleLeave> AddSingleLeaveAsync(SingleLeave singleLeave)
        {
            await context.SingleLeaves.AddAsync(singleLeave);
            await SaveChangesAsync();
            return singleLeave;
        }
        public async Task<bool> SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }
    }
}
