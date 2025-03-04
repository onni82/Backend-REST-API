using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        [MaxLength(50)]
        public string School { get; set; }
		[MaxLength(50)]
		public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation property
        public List<PersonEducation> PersonEducations { get; set; } = new();
    }
}
