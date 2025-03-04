using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_REST_API.Models
{
	public class WorkExperience
	{
		[Key]
		public int WorkExperienceId { get; set; }

		[MaxLength(50)]
		public string JobTitle { get; set; }

		[MaxLength(50)]
		public string Company { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		[ForeignKey("Person")]
		public int PersonId { get; set; }
		public Person? Person { get; set; }
	}
}
