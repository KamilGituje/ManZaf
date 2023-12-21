using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class SingleLeave
    {
        public int SingleLeaveId { get; set; }
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
        public SingleLeaveStatus Status { get; set; }
        public int WorkerId { get; set; }
        public int LeaveTypeId { get; set; }   
        public Worker Worker { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
