using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface ISingleLeaveService
    {
        Task<SingleLeave> AddSingleLeaveAsync(SingleLeave singleLeave);
        Task<SingleLeave> UpdateSingleLeaveStatus(SingleLeave singleLeave);
    }
}
