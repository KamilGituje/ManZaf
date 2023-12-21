namespace ManZafAPI.Models
{
    public class SingleLeaveWithIdsDto
    {
        public int SingleLeaveId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int WorkerId { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
