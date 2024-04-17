using System.ComponentModel.DataAnnotations.Schema;

namespace Examination_Program_MVC.Models;

public class Exam
{
	public int Id { get; set; }

	[ForeignKey("Course")]
	public int CourseId { get; set; } 
	public Course Course { get; set; }


	[ForeignKey("Student")]
	public int StudentId { get; set; }
	public Student Student { get; set; }

	public DateTime ExamDate { get; set; } 
	public int Grade { get; set; } 


}
