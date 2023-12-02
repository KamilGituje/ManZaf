using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class LeaveForUpdate
    {
        public int WorkerId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
