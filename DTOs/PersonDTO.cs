namespace Backend_REST_API.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }
    }
}
