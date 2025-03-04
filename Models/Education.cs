using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_REST_API.Models
{
	public class Education
	{
		[Key]
		public int EducationId { get; set; }

		[Required]
		[MaxLength(50)]
		public string School { get; set; }

		[Required]
		[MaxLength(50)]
		public string Degree { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		[ForeignKey("Person")]
		public int PersonId { get; set; }
		public Person? Person { get; set; }
	}
}
