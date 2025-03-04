using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }

		[Required]
		[MaxLength(50)]
		public required string Name { get; set; }

		[Required]
		[MaxLength(50)]
		public required string Email { get; set; }

		[Required]
		[Phone]
		public required string Phone { get; set; }

		public List<Education> Educations { get; set; } = new();
		public List<WorkExperience> WorkExperiences { get; set; } = new();
	}
}
