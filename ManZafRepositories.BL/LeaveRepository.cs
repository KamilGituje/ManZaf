using AutoMapper;
using ManZafDatabase;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class LeaveRepository : ILeaveRepository
    {
        public LeaveRepository(PubContext _context)
        {
            context = _context;
        }
        private readonly PubContext context;

        public async Task<Leave> GetLeaveTypeAsync(int leaveId)
        {
            return await context.Leaves.FirstOrDefaultAsync(l => l.LeaveId == leaveId);
        }
        public async Task<List<WorkerLeave>> GetAvailableLeavesForWorker(int workerId)
        {
            return await context.WorkerLeave.Include(wl => wl.Leave).Where(wl => wl.WorkerId == workerId).ToListAsync();
        }
        public async Task<WorkerLeave> GetAvailableLeaveSpecificTypeForWorkerAsync(int workerId, int leaveId)
        {
            return await context.WorkerLeave.Include(wl => wl.Leave).FirstOrDefaultAsync(wl => wl.LeaveId == leaveId && wl.WorkerId == workerId);
        }
        public async Task<bool> AddNewNonExistingLeaveForWorkerAsync(WorkerLeave leave)
        {
            await context.WorkerLeave.AddAsync(leave);
            return true;
        }
        public async Task<bool> SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }
    }
}