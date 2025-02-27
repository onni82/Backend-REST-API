namespace Backend_REST_API.Models
{
    public class PersonWorkExperience
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int WorkID { get; set; }
        public WorkExperience WorkExperience { get; set; }
    }
}
