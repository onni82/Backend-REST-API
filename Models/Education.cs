namespace Backend_REST_API.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string School { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
