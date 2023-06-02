using System;
using Exercise_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.Data
{
	public class ExerciseContext:DbContext
	{
		public ExerciseContext(DbContextOptions<ExerciseContext> options):base(options)
		{
		}
		public DbSet<Exercise> exercises { get; set; }
	}
}

