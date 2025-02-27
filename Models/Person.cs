namespace Backend_REST_API.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Navigation properties
        public List<PersonEducation> PersonEducations { get; set; } = new();
        public List<PersonWorkExperience> PersonWorkExperiences { get; set; } = new();
    }
}
