using Backend_REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_REST_API.Data
{
    public class RestApiDbContext : DbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
