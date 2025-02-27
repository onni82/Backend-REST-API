using Backend_REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_REST_API.Data
{
    public class RestApiDbContext : DbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<PersonWorkExperience> PersonWorkExperiences { get; set; }
        public DbSet<PersonEducation> PersonEducations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many between Person and WorkExperience
            modelBuilder.Entity<PersonWorkExperience>()
                .HasKey(pw => new { pw.PersonID, pw.WorkID });

            modelBuilder.Entity<PersonWorkExperience>()
                .HasOne(pw => pw.Person)
                .WithMany(p => p.PersonWorkExperiences)
                .HasForeignKey(pw => pw.PersonID);

            modelBuilder.Entity<PersonWorkExperience>()
                .HasOne(pw => pw.WorkExperience)
                .WithMany(w => w.PersonWorkExperiences)
                .HasForeignKey(pw => pw.WorkID);

            // Many-to-Many between Person and Education
            modelBuilder.Entity<PersonEducation>()
                .HasKey(pe => new { pe.PersonID, pe.EducationID });

            modelBuilder.Entity<PersonEducation>()
                .HasOne(pe => pe.Person)
                .WithMany(p => p.PersonEducations)
                .HasForeignKey(pe => pe.PersonID);

            modelBuilder.Entity<PersonEducation>()
                .HasOne(pe => pe.Education)
                .WithMany(e => e.PersonEducations)
                .HasForeignKey(pe => pe.EducationID);
        }
    }
}
