using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        // Navigation properties
        public List<PersonEducation> PersonEducations { get; set; } = new();
        public List<PersonWorkExperience> PersonWorkExperiences { get; set; } = new();
    }
}
