using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface ISingleLeaveRepository
    {
        Task<SingleLeave> GetAsync(int singleLeaveId);
        Task<List<SingleLeave>> GetSingleLeavesAsync(int workerId);
        Task<List<SingleLeave>> GetSingleLeavesByManagerIdAsync(int managerId);
        Task<List<SingleLeave>> GetSingleLeavesUnmanagedByManagerIdAsync(int managerId);
        Task<SingleLeave> AddSingleLeaveAsync(SingleLeave singleLeave);
        Task<bool> SaveChangesAsync();
    }
}
