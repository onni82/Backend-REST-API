using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_REST_API.Models
{
    public class PersonWorkExperience
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("WorkExperience")]
        public int WorkId { get; set; }
        public WorkExperience WorkExperience { get; set; }
    }
}
