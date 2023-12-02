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
        Task<Leave> GetLeaveTypeAsync(int leaveId);
        Task<List<WorkerLeave>> GetAvailableLeavesForWorker(int workerId);
        Task<WorkerLeave> GetAvailableLeaveSpecificTypeForWorkerAsync(int workerId, int leaveId);
        Task<bool> AddNewNonExistingLeaveForWorkerAsync(WorkerLeave leave);
        Task<bool> SaveChangesAsync();
    }
}
