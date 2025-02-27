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
                var people = await context.Persons.Include(p => p.Educations).Include(p => p.WorkExperiences).ToListAsync();
                return Results.Ok(people);
            });

            app.MapGet("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons.Include(p => p.Educations)
                                                  .Include(p => p.WorkExperiences)
                                                  .FirstOrDefaultAsync(p => p.Id == id);

                return person is not null ? Results.Ok(person) : Results.NotFound();
            });


            app.MapPost("/persons", async (Person person, RestApiDbContext context) =>
            {
                context.Persons.Add(person);
                await context.SaveChangesAsync();
                return Results.Created($"/persons/{person.Id}", person);
            });

            app.MapPut("/persons/{id}", async (int id, Person updatedPerson, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                person.Name = updatedPerson.Name;
                person.Description = updatedPerson.Description;
                person.Email = updatedPerson.Email;

                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons.FindAsync(id);
                if (person == null) return Results.NotFound();

                context.Persons.Remove(person);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
