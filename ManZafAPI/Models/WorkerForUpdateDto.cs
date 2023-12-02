using ManZafModels.BL;

namespace ManZafAPI.Models
{
    public class WorkerForUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? HiringDate { get; set; }
        public int? ManagerId { get; set; }
    }
}
