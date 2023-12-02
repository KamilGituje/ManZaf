using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class WorkerLeaveForUpdate
    {
        public int WorkerId { get; set; }
        public int LeaveId { get; set; }
        public int Quantity { get; set; }
    }
}
