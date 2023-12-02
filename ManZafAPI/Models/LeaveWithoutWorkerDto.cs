using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class LeaveWithoutWorkerDto
    {
        public LeaveType LeaveType { get; set; }
        public int Quantity { get; set; }
    }
}