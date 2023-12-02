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

        public async Task<LeaveType> GetLeaveTypeAsync(int leaveTypeId)
        {
            return await context.LeaveTypes.FirstOrDefaultAsync(l => l.LeaveTypeId == leaveTypeId);
        }
        public async Task<List<Leave>> GetAvailableLeavesForWorker(int workerId)
        {
            return await context.Leaves.Include(wl => wl.LeaveType).Where(wl => wl.WorkerId == workerId).ToListAsync();
        }
        public async Task<Leave> GetAvailableLeaveSpecificTypeForWorkerAsync(int workerId, int leaveTypeId)
        {
            return await context.Leaves.Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.LeaveTypeId == leaveTypeId && l.WorkerId == workerId);
        }
        public async Task<bool> AddNewNonExistingLeaveForWorkerAsync(Leave leave)
        {
            await context.Leaves.AddAsync(leave);
            return true;
        }
        public async Task<bool> SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }
    }
}