using ManZafDatabase;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public LeaveTypeRepository(PubContext _context)
        {
            context = _context;
        }
        private readonly PubContext context;

        public async Task<LeaveType> GetLeaveTypeAsync(int leaveTypeId)
        {
            return await context.LeaveTypes.FirstOrDefaultAsync(l => l.LeaveTypeId == leaveTypeId);
        }
    }
}
