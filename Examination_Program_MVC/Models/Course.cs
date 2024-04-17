namespace Examination_Program_MVC.Models;

public class Course
{
	public int Id { get; set; } 
	public string CourseCode { get; set; }
	public string CourseName { get; set; } 
	public int Class { get; set; } 
	public string TeacherFirstName { get; set; } 
	public string TeacherLastName { get; set; }

	public ICollection<Exam> Exams { get; set; }
}
