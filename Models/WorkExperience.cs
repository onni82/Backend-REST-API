using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkId { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }

        // Navigation property
        public List<PersonWorkExperience> PersonWorkExperiences { get; set; } = new();
    }
}
