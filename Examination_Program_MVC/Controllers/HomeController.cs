using Examination_Program_MVC.Data;
using Examination_Program_MVC.Models;
using Examination_Program_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Examination_Program_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }
	public IActionResult Index()
    {
        var exams = _db.Exams
    .Include(e => e.Course)
    .Include(e => e.Student).ToList();

		return View(exams);
    }


	public IActionResult Create()
	{
		ExamVM examVM = new()
		{
			CourseList = _db.Courses.Select(u => new SelectListItem
			{

				Text = u.CourseName,
				Value = u.Id.ToString()
			}),

			StudentList = _db.Students.Select(u => new SelectListItem
			{

				Text = u.FirstName + " " + u.LastName,
				Value = u.Id.ToString()
			}),
			Exam = new Exam()
		};
	
			return View(examVM);

	}


	[HttpPost]
	public IActionResult Create(ExamVM examVM)
	{
		if (ModelState.IsValid)
		{
			_db.Exams.Add(examVM.Exam);
			_db.SaveChanges();
			TempData["success"] = "Exam added successfully";
			return RedirectToAction("Index");
		}
		return View(examVM);
	}


	public IActionResult Edit(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var examFromDb = _db.Exams.FirstOrDefault(u => u.Id == id);

		if (examFromDb == null)
		{
			return NotFound();
		}

		ExamVM examVM = new ExamVM
		{
			Exam = examFromDb,
			CourseList = _db.Courses.Select(c => new SelectListItem
			{
				Text = c.CourseName,
				Value = c.Id.ToString(),
				Selected = c.Id == examFromDb.CourseId

			}),
			StudentList = _db.Students.Select(s => new SelectListItem
			{
				Text = s.FirstName + " " + s.LastName,
				Value = s.Id.ToString(),
				Selected = s.Id == examFromDb.StudentId
			})
		};

		return View(examVM);
	}

	[HttpPost]
	public IActionResult Edit(int id, ExamVM examVM)
	{
		if (id != examVM.Exam.Id)
		{
			return BadRequest();
		}

		if (ModelState.IsValid)
		{
			Exam existingExam = _db.Exams.FirstOrDefault(u => u.Id == id);

			if (existingExam == null)
			{
				return NotFound();
			}

			existingExam.CourseId = examVM.Exam.CourseId;
			existingExam.StudentId = examVM.Exam.StudentId;
			existingExam.ExamDate = examVM.Exam.ExamDate;
			existingExam.Grade = examVM.Exam.Grade;

			_db.SaveChanges();

			TempData["success"] = "Exam updated successfully";
			return RedirectToAction("Index");
		}

		examVM.CourseList = _db.Courses.Select(c => new SelectListItem
		{
			Text = c.CourseName,
			Value = c.Id.ToString(),
			Selected = c.Id == examVM.Exam.CourseId
		});

		examVM.StudentList = _db.Students.Select(s => new SelectListItem
		{
			Text = s.FirstName + " " + s.LastName,
			Value = s.Id.ToString(),
			Selected = s.Id == examVM.Exam.StudentId
		});

		return View(examVM);
	}


	public IActionResult Delete(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}

		var examFromDb = _db.Exams.Include(e => e.Course).Include(e => e.Student)
			.FirstOrDefault(u => u.Id == id);

		if (examFromDb == null)
		{
			return NotFound();
		}

		return View(examFromDb);
	}



	[HttpPost]
	public IActionResult Delete(Exam obj)
	{

		_db.Exams.Remove(obj);
		_db.SaveChanges();
		TempData["success"] = "Exam deleted successfully";
		return RedirectToAction("Index");
	}
}
