﻿using System.ComponentModel.DataAnnotations;

namespace Backend_REST_API.Models
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(50)]
		public string Email { get; set; }

		[Phone]
		public string Phone { get; set; }

		public List<Education> Educations { get; set; } = new();
		public List<WorkExperience> WorkExperiences { get; set; } = new();
	}
}
