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
        Task<List<Leave>> GetAvailableLeaves(int workerId);
        Task<Leave> GetAvailableLeaveSpecificTypeAsync(int workerId, int leaveTypeId);
        Task<bool> AddNewNonExistingLeaveAsync(Leave leave);
        Task<bool> SaveChangesAsync();
    }
}
