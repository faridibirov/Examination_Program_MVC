using Examination_Program_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_Program_MVC.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Student> Students { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Exam> Exams { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Seed data for courses
		modelBuilder.Entity<Course>().HasData(
			new Course
			{
				Id = 1,
				CourseCode = "MTH",
				CourseName = "Mathematics",
				Class = 9,
				TeacherFirstName = "John",
				TeacherLastName = "Doe"
			},
			new Course
			{
				Id = 2,
				CourseCode = "SCI",
				CourseName = "Science",
				Class = 9,
				TeacherFirstName = "Jane",
				TeacherLastName = "Smith"
			}

		);


		modelBuilder.Entity<Student>().HasData(
			new Student
			{
				Id = 1,
				StudentNumber = 1001,
				FirstName = "Alice",
				LastName = "Johnson",
				Class = 9
			},
			new Student
			{
				Id = 2,
				StudentNumber = 1002,
				FirstName = "Bob",
				LastName = "Williams",
				Class = 9
			}
		);

		modelBuilder.Entity<Exam>().HasData(
			new Exam
			{
				Id = 1,
				CourseId = 1,
				StudentId = 1,
				ExamDate = new DateTime(2024, 4, 15),
				Grade = 8
			},
			new Exam
			{
				Id = 2,
				CourseId = 2,
				StudentId = 2,
				ExamDate = new DateTime(2024, 4, 16),
				Grade = 7
			}
		);
	}

}
