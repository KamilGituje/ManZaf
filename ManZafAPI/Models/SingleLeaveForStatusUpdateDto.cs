using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class SingleLeaveForStatusUpdateDto
    {
        public int SingleLeaveId { get; set; }
        public SingleLeaveStatus Status { get; set; }
    }
}
