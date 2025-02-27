namespace Backend_REST_API.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation property
        public List<PersonEducation> PersonEducations { get; set; } = new();
    }
}
