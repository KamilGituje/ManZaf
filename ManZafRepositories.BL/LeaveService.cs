using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class LeaveService : ILeaveService
    {
        public LeaveService(ILeaveRepository _leaveRepository) 
        {
            leaveRepository = _leaveRepository;
        }
        private readonly ILeaveRepository leaveRepository;

        public async Task<WorkerLeave> UpdateAvailableLeavesForWorker(WorkerLeave leave)
        {
            var leaveToUpdate = await leaveRepository.GetAvailableLeaveSpecificTypeForWorkerAsync(leave.WorkerId, leave.LeaveId);
            if(leaveToUpdate == null)
            {
                leaveToUpdate = new WorkerLeave()
                {
                    LeaveId = leave.LeaveId,
                    WorkerId = leave.WorkerId,
                    Quantity = leave.Quantity,
                };
                await leaveRepository.AddNewNonExistingLeaveForWorkerAsync(leaveToUpdate);
            }
            leaveToUpdate.Quantity = leave.Quantity;
            await leaveRepository.SaveChangesAsync();
            return leaveToUpdate;
        }
    }
}
