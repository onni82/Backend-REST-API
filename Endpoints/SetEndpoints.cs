using Backend_REST_API.Data;
using Backend_REST_API.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend_REST_API.Endpoints.SetEndpoints
{
    public class SetEndpoints
    {
        public async static void RegisterEndpoints(WebApplication app)
        {
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

            app.MapGet("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons
                    .Include(p => p.PersonEducations)
                        .ThenInclude(pe => pe.Education)
                    .Include(p => p.PersonWorkExperiences)
                        .ThenInclude(pw => pw.WorkExperience)
                    .FirstOrDefaultAsync(p => p.PersonID == id);

                return person is not null ? Results.Ok(person) : Results.NotFound();
            });


            app.MapPost("/persons", async (Person person, RestApiDbContext context) =>
            {
                context.Persons.Add(person);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{person.PersonID}", person);
            });

            app.MapPut("/persons/{id}", async (int id, Person updatedPerson, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                person.Name = updatedPerson.Name;
                person.Email = updatedPerson.Email;

                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                // Remove related entries in many-to-many tables
                var personEducations = context.PersonEducations.Where(pe => pe.PersonID == id);
                var personWorkExperiences = context.PersonWorkExperiences.Where(pw => pw.PersonID == id);
                context.PersonEducations.RemoveRange(personEducations);
                context.PersonWorkExperiences.RemoveRange(personWorkExperiences);

                // Remove person
                context.Persons.Remove(person);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
