using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_REST_API.Models
{
	public class WorkExperience
	{
		[Key]
		public int WorkExperienceId { get; set; }

		[Required]
		[MaxLength(50)]
		public required string JobTitle { get; set; }

		[Required]
		[MaxLength(50)]
		public required string Company { get; set; }

		[Required]
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		[ForeignKey("Person")]
		public int PersonId { get; set; }
		public Person? Person { get; set; }
	}
}
