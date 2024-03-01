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

        public async Task<Leave> UpdateAvailableLeaveForWorker(Leave leave)
        {
            var leaveToUpdate = await leaveRepository.GetAvailableLeaveSpecificTypeAsync(leave.WorkerId, leave.LeaveTypeId);
            if(leaveToUpdate == null)
            {
                leaveToUpdate = CreateNewNonExistingLeaveForWorker(leave.WorkerId, leave.LeaveTypeId);
                leaveToUpdate.Quantity = leave.Quantity;
                await leaveRepository.AddNewNonExistingLeaveAsync(leaveToUpdate);
            }
            leaveToUpdate.Quantity = leave.Quantity;
            await leaveRepository.SaveChangesAsync();
            return leaveToUpdate;
        }
        public async Task<Leave> AddDaysToLeaveForWorkerAsync(Leave leave, int daysNumber)
        {
            var leaveToAddDaysTo = await leaveRepository.GetAvailableLeaveSpecificTypeAsync(leave.WorkerId, leave.LeaveTypeId);
            if (leaveToAddDaysTo == null)
            {
                leaveToAddDaysTo = CreateNewNonExistingLeaveForWorker(leave.WorkerId, leave.LeaveTypeId);
                await leaveRepository.AddNewNonExistingLeaveAsync(leaveToAddDaysTo);
            }
            leaveToAddDaysTo.Quantity += daysNumber;
            await leaveRepository.SaveChangesAsync();
            return leaveToAddDaysTo;
        }
        private Leave CreateNewNonExistingLeaveForWorker(int workerId, int leaveTypeId)
        {
            return new Leave()
            {
                WorkerId = workerId,
                LeaveTypeId = leaveTypeId,
                Quantity = 0
            };
        }
    }
}
