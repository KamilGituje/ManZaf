using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface ILeaveService
    {
        Task<Leave> UpdateAvailableLeavesForWorker(Leave leave);
    }
}
