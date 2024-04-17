using Examination_Program_MVC.Data;
using Examination_Program_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Examination_Program_MVC.Controllers;

public class StudentController : Controller
{
	private readonly ApplicationDbContext _db;

	public StudentController(ApplicationDbContext db)
	{
		_db = db;
	}

	public IActionResult Index()
	{
		var students = _db.Students.ToList();
		return View(students);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Create(Student student)
	{
		if (ModelState.IsValid)
		{
			_db.Students.Add(student);
			_db.SaveChanges();
			TempData["success"] = "Student added successfully" ;
			return RedirectToAction("Index");
		}
		return View(student);
	}

	public IActionResult Edit (int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var studentFromDb = _db.Students.FirstOrDefault(u => u.Id == id);

		if (studentFromDb == null)
		{
			return NotFound();
		}
		return View(studentFromDb);
	}

	[HttpPost]
	public IActionResult Edit(Student obj)
	{

		if (ModelState.IsValid)
		{
			_db.Students.Update(obj);
			_db.SaveChanges();
            TempData["success"] = "Student info edited successfully";
            return RedirectToAction("Index");
		}
		return View();
	}


	public IActionResult Delete(int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var studentFromDb = _db.Students.FirstOrDefault(u => u.Id == id);

		if (studentFromDb == null)
		{
			return NotFound();
		}
		return View(studentFromDb);
	}

	[HttpPost]
	public IActionResult Delete(Student obj)
	{

			_db.Students.Remove(obj);
			_db.SaveChanges();
        TempData["success"] = "Student deleted successfully";
        return RedirectToAction("Index");
	}

}
