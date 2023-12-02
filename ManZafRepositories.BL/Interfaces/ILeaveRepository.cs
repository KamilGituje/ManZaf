using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface ILeaveRepository
    {
        Task<LeaveType> GetLeaveTypeAsync(int leaveId);
        Task<List<Leave>> GetAvailableLeavesForWorker(int workerId);
        Task<Leave> GetAvailableLeaveSpecificTypeForWorkerAsync(int workerId, int leaveId);
        Task<bool> AddNewNonExistingLeaveForWorkerAsync(Leave leave);
        Task<bool> SaveChangesAsync();
    }
}
