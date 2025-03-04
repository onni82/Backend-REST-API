using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkId { get; set; }
		[MaxLength(50)]
		public string JobTitle { get; set; }
		[MaxLength(50)]
		public string Company { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		// Navigation property
		public List<PersonWorkExperience> PersonWorkExperiences { get; set; } = new();
    }
}
