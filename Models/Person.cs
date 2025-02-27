namespace Backend_REST_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Education> Educations { get; set; } = new();
        public List<WorkExperience> WorkExperiences { get; set; } = new();
    }
}
