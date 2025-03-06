namespace Backend_REST_API.DTOs
{
    public class EducationDTO
    {
        public int EducationId { get; set; }
        public required string School { get; set; }
        public required string Degree { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
