using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class WorkerLeaveDto
    {
        public int WorkerId { get; set; }
        public int LeaveId { get; set; }
        public int Quantity { get; set; }
    }
}
