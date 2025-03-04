﻿using Backend_REST_API.Data;
using Backend_REST_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
namespace Backend_REST_API.Endpoints.SetEndpoints
{
    public class SetEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // Get all persons with their related data
            app.MapGet("/persons", async (RestApiDbContext context) =>
            {
                var people = await context.Persons
                    .Include(p => p.Educations)
                    .Include(p => p.WorkExperiences)
                    .ToListAsync();

                return Results.Ok(people);
            });

            // Get a person by ID, including educations and work experiences
            app.MapGet("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
                var person = await context.Persons
                    .Include(p => p.Educations)
                    .Include(p => p.WorkExperiences)
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
				person.Phone = updatedPerson.Phone;

				await context.SaveChangesAsync();
				return Results.NoContent();
			});


			// Delete a person and their associated Educations and Work Experiences
			app.MapDelete("/persons/{id}", async (int id, RestApiDbContext context) =>
            {
				var person = await context.Persons
					.Include(p => p.Educations)
					.Include(p => p.WorkExperiences)
					.FirstOrDefaultAsync(p => p.PersonId == id);

				if (person == null) return Results.NotFound();

				context.Educations.RemoveRange(person.Educations);
				context.WorkExperiences.RemoveRange(person.WorkExperiences);
				context.Persons.Remove(person);

				await context.SaveChangesAsync();
				return Results.NoContent();
			});

			// Add an education to a person
			app.MapPost("/persons/{id}/educations", async (int id, Education education, RestApiDbContext context) =>
			{
				if (id <= 0) return Results.BadRequest("Invalid PersonId.");

				var person = await context.Persons.FindAsync(id);
				if (person == null) return Results.NotFound("Person not found");

				education.PersonId = id;
				context.Educations.Add(education);
				await context.SaveChangesAsync();

				return Results.Created($"/educations/{education.EducationId}", education);
			});

			// Remove an education from a person
			app.MapDelete("/persons/{id}/educations/{educationId}", async (int id, int educationId, RestApiDbContext context) =>
			{
				var education = await context.Educations
					.FirstOrDefaultAsync(e => e.PersonId == id && e.EducationId == educationId);

				if (education == null)
					return Results.NotFound("Education not found");

				context.Educations.Remove(education);
				await context.SaveChangesAsync();

				return Results.NoContent();
			});

			// Update an education record
			app.MapPut("/educations/{educationId}", async (int educationId, Education updatedEducation, RestApiDbContext context) =>
			{
				var education = await context.Educations.FindAsync(educationId);
				if (education == null) return Results.NotFound("Education not found");

				// Update only the necessary fields
				education.Degree = updatedEducation.Degree;
				education.School = updatedEducation.School;
				education.StartDate = updatedEducation.StartDate;
				education.EndDate = updatedEducation.EndDate;

				await context.SaveChangesAsync();
				return Results.Ok("Education updated successfully");
			});

			// Get all educations
			app.MapGet("/educations", async (RestApiDbContext context) =>
			{
				var educations = await context.Educations.ToListAsync();
				return Results.Ok(educations);
			});

			// Add a work experience to a person
			app.MapPost("/persons/{id}/workexperiences", async (int id, WorkExperience workExperience, RestApiDbContext context) =>
			{
				if (id <= 0) return Results.BadRequest("Invalid PersonId.");

				var person = await context.Persons.FindAsync(id);
				if (person == null) return Results.NotFound("Person not found");

				workExperience.PersonId = id;
				context.WorkExperiences.Add(workExperience);
				await context.SaveChangesAsync();

				return Results.Created($"/workexperiences/{workExperience.WorkExperienceId}", workExperience);
			});

			// Remove a work experience from a person
			app.MapDelete("/persons/{id}/workexperiences/{workId}", async (int id, int workId, RestApiDbContext context) =>
			{
				var workExperience = await context.WorkExperiences
					.FirstOrDefaultAsync(we => we.PersonId == id && we.WorkExperienceId == workId);

				if (workExperience == null)
					return Results.NotFound("Work experience not found");

				context.WorkExperiences.Remove(workExperience);
				await context.SaveChangesAsync();

				return Results.NoContent();
			});

			//Update a work experience record
			app.MapPut("/workexperiences/{workExperienceId}", async (int workExperienceId, WorkExperience updatedWorkExperience, RestApiDbContext context) =>
			{
				var workExperience = await context.WorkExperiences.FindAsync(workExperienceId);
				if (workExperience == null) return Results.NotFound("Work experience not found");

				// Update only the necessary fields
				workExperience.JobTitle = updatedWorkExperience.JobTitle;
				workExperience.Company = updatedWorkExperience.Company;
				workExperience.StartDate = updatedWorkExperience.StartDate;
				workExperience.EndDate = updatedWorkExperience.EndDate;

				await context.SaveChangesAsync();
				return Results.Ok("Work experience updated successfully");
			});

			// Get all work experiences
			app.MapGet("/workexperiences", async (RestApiDbContext context) =>
			{
				var workExperiences = await context.WorkExperiences.ToListAsync();
				return Results.Ok(workExperiences);
			});

			// Get GitHub repositories
			app.MapGet("/github/{username}", async (string username) =>
			{
				using var httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

				var url = $"https://api.github.com/users/{username}/repos";
				var repositories = await httpClient.GetFromJsonAsync<List<GitHubRepo>>(url);

				if (repositories == null || repositories.Count == 0)
				{
					return Results.NotFound("No public repositories could be found for this user.");
				}

				var result = repositories.Select(repo => new
				{
					Name = repo.Name,
					Language = string.IsNullOrEmpty(repo.Language) ? "unknown" : repo.Language,
					Description = string.IsNullOrEmpty(repo.Description) ? "saknas" : repo.Description,
					Url = repo.HtmlUrl
				});

				return Results.Ok(result);
			});
		}
    }
	public class GitHubRepo
	{
		public string Name { get; set; }
		public string Language { get; set; }
		public string Description { get; set; }
		public string HtmlUrl { get; set; }
	}
}
