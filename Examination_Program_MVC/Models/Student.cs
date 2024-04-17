namespace Examination_Program_MVC.Models;

public class Student
{
	public int Id { get; set; } 
	public int StudentNumber { get; set; }
	public string FirstName { get; set; } 
	public string LastName { get; set; }
	public int Class { get; set; }

	public ICollection<Exam> Exams { get; set; }
}
