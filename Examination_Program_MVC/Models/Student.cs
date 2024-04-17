using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Examination_Program_MVC.Models;

public class Student
{
	public int Id { get; set; }

	[Display(Name = "Student Number")]
	public int StudentNumber { get; set; }

	[Display(Name = "First Name")]
	public string FirstName { get; set; }

	[Display(Name = "Last Name")]
	public string LastName { get; set; }

	[Display(Name = "Class")]
	public int Class { get; set; }

	[ValidateNever]
	public ICollection<Exam> Exams { get; set; }
}
