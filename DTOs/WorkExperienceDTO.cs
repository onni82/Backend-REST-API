namespace Backend_REST_API.DTOs
{
    public class WorkExperienceDTO
    {
        public int WorkExperienceId { get; set; }
        public required string JobTitle { get; set; }
        public required string Company { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
