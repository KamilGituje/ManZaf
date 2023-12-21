using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class SingleLeaveForCreationDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int WorkerId { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
