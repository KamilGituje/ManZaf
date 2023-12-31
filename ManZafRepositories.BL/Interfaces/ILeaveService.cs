﻿using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface ILeaveService
    {
        Task<Leave> UpdateAvailableLeaveForWorker(Leave leave);
        Task<Leave> AddDaysToLeaveForWorkerAsync(Leave leave, int daysNumber);
    }
}
