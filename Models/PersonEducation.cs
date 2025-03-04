using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_REST_API.Models
{
    public class PersonEducation
    {
		[Key]
		public int PersonEducationId { get; set; }
		[ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Education")]
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
