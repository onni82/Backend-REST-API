using Backend_REST_API.Data;
using Backend_REST_API.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend_REST_API.Endpoints.SetEndpoints
{
    public class SetEndpoints
    {
        public async static void RegisterEndpoints(WebApplication app)
        {
            // Get all persons with their related data
            app.MapGet("/persons", async (RestApiDbContext context) =>
            {
                var people = await context.Persons
                    .Include(p => p.PersonEducations)
                        .ThenInclude(pe => pe.Education)
                    .Include(p => p.PersonWorkExperiences)
                        .ThenInclude(pw => pw.WorkExperience)
                    .ToListAsync();

                return Results.Ok(people);
            });

            // Get a person by ID, including educations and work experiences
            app.MapGet("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons
                    .Include(p => p.PersonEducations)
                        .ThenInclude(pe => pe.Education)
                    .Include(p => p.PersonWorkExperiences)
                        .ThenInclude(pw => pw.WorkExperience)
                    .FirstOrDefaultAsync(p => p.PersonId == id);

                return person is not null ? Results.Ok(person) : Results.NotFound();
            });

            // Create a new person
            app.MapPost("/persons", async (Person person, RestApiDbContext context) =>
            {
                context.Persons.Add(person);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{person.PersonId}", person);
            });

            // Update a person
            app.MapPut("/persons/{id}", async (int id, Person updatedPerson, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                person.Name = updatedPerson.Name;
                person.Email = updatedPerson.Email;

                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            // Delete a person and remove their relationships first
            app.MapDelete("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                // Remove related entries in many-to-many tables
                var personEducations = context.PersonEducations.Where(pe => pe.PersonId == id);
                var personWorkExperiences = context.PersonWorkExperiences.Where(pw => pw.PersonId == id);
                context.PersonEducations.RemoveRange(personEducations);
                context.PersonWorkExperiences.RemoveRange(personWorkExperiences);

                // Remove person
                context.Persons.Remove(person);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            // Add an education to a person
            app.MapPost("/persons/{id}/educations/{educationId}", async (int id, int educationId, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                var education = await context.Educations.FindAsync(educationId);

                if (person is null || education is null)
                    return Results.NotFound("Person or Education not found");

                var personEducation = new PersonEducation { PersonId = id, EducationId = educationId };
                context.PersonEducations.Add(personEducation);
                await context.SaveChangesAsync();

                return Results.Ok("Education added to person");
            });

            // Remove an education from a person
            app.MapDelete("/persons/{id}/educations/{educationId}", async (int id, int educationId, RestApiDbContext context) =>
            {
                var personEducation = await context.PersonEducations
                    .FirstOrDefaultAsync(pe => pe.PersonId == id && pe.EducationId == educationId);

                if (personEducation is null)
                    return Results.NotFound("Education relationship not found");

                context.PersonEducations.Remove(personEducation);
                await context.SaveChangesAsync();

                return Results.Ok("Education removed from person");
            });

            // Add a work experience to a person
            app.MapPost("/persons/{id}/workexperiences/{workId}", async (int id, int workId, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                var workExperience = await context.WorkExperiences.FindAsync(workId);

                if (person is null || workExperience is null)
                    return Results.NotFound("Person or Work Experience not found");

                var personWorkExperience = new PersonWorkExperience { PersonId = id, WorkId = workId };
                context.PersonWorkExperiences.Add(personWorkExperience);
                await context.SaveChangesAsync();

                return Results.Ok("Work experience added to person");
            });

            // Remove a work experience from a person
            app.MapDelete("/persons/{id}/workexperiences/{workId}", async (int id, int workId, RestApiDbContext context) =>
            {
                var personWorkExperience = await context.PersonWorkExperiences
                    .FirstOrDefaultAsync(pw => pw.PersonId == id && pw.WorkId == workId);

                if (personWorkExperience is null)
                    return Results.NotFound("Work experience relationship not found");

                context.PersonWorkExperiences.Remove(personWorkExperience);
                await context.SaveChangesAsync();

                return Results.Ok("Work experience removed from person");
            });
        }
    }
}
