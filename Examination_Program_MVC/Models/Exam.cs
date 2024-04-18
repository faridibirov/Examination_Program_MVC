using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Program_MVC.Models;

public class Exam
{
	public int Id { get; set; }

	[Display(Name = "Course")]
	[ForeignKey("Course")]
	public int CourseId { get; set; }
	[ValidateNever]
	public Course Course { get; set; }

	[Display(Name = "Student")]
	[ForeignKey("Student")]
	public int StudentId { get; set; }
	[ValidateNever]
	public Student Student { get; set; }

	public DateTime ExamDate { get; set; } 
	public int Grade { get; set; } 


}
