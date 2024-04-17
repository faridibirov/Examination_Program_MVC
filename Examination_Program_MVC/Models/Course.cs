using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Examination_Program_MVC.Models;

public class Course
{
	public int Id { get; set; }

	[Display(Name = "Course Code")]
	public string CourseCode { get; set; }

	[Display(Name = "Course Name")]
	public string CourseName { get; set; }

	[Display(Name = "Class")]
	public int Class { get; set; }

	[Display(Name = "Teacher's First Name")]
	public string TeacherFirstName { get; set; }

	[Display(Name = "Teacher's Last Name")]
	public string TeacherLastName { get; set; }

	[ValidateNever]
	public ICollection<Exam> Exams { get; set; }
}
