using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class SingleLeaveDto
    {
        public int SingleLeaveId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Worker Worker { get; set; }
        public LeaveType LeaveType { get; set; }
        public SingleLeaveStatus Status { get; set; }
    }
}