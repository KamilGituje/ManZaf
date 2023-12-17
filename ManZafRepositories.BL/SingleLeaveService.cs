using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class SingleLeaveService : ISingleLeaveService
    {
        public SingleLeaveService(ISingleLeaveRepository _singleLeaveRepository, ILeaveRepository _leaveRepository)
        { 
            singleLeaveRepository = _singleLeaveRepository;
            leaveRepository = _leaveRepository;
        }
        private readonly ISingleLeaveRepository singleLeaveRepository;
        private readonly ILeaveRepository leaveRepository;

        public async Task<SingleLeave> AddSingleLeaveAsync(SingleLeave singleLeave)
        {
            if (singleLeave.StartDate <= singleLeave.EndDate)
            {
                var availableLeave = await leaveRepository.GetAvailableLeaveSpecificTypeForWorkerAsync(singleLeave.WorkerId, singleLeave.LeaveTypeId);
                if (availableLeave != null)
                {
                    var requestedDays = RemoveWeekends(singleLeave.StartDate, singleLeave.EndDate);
                    if (availableLeave.Quantity > requestedDays)
                    {
                        await singleLeaveRepository.AddSingleLeaveAsync(singleLeave);
                        availableLeave.Quantity -= requestedDays;
                        await singleLeaveRepository.SaveChangesAsync();
                        return singleLeave;
                    }
                }
            }
            return null;
        }
        private int RemoveWeekends(DateOnly startDate, DateOnly endDate)
        {
            var allDays = endDate.DayNumber - startDate.DayNumber + 1;
            var daysBeforeFirstWeekend = 6 - (int)startDate.DayOfWeek;
            var daysAfterLastWeekend = (int)endDate.DayOfWeek % 7;
            var weekendDays = (((allDays - daysBeforeFirstWeekend - daysAfterLastWeekend - 2) / 7) * 2) + 2;
            return allDays - weekendDays;
        }
    }
}
