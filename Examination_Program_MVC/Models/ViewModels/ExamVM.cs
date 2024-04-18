using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examination_Program_MVC.Models.ViewModels;

public class ExamVM
{
	public Exam Exam { get; set; }

	[ValidateNever]
	public IEnumerable<SelectListItem> CourseList { get; set; }

	[ValidateNever]
	public IEnumerable<SelectListItem> StudentList { get; set; }
}