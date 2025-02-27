namespace Backend_REST_API.Models
{
    public class PersonEducation
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int EducationID { get; set; }
        public Education Education { get; set; }
    }
}
