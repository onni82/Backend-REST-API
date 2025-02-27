namespace Backend_REST_API.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
