using Examination_Program_MVC.Data;
using Examination_Program_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Examination_Program_MVC.Controllers;

public class CourseController : Controller
{
	private readonly ApplicationDbContext _db;

	public CourseController(ApplicationDbContext db)
	{
		_db = db;
	}

	public IActionResult Index()
	{
		var courses = _db.Courses.ToList();
		return View(courses);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Create(Course course)
	{
		if (ModelState.IsValid)
		{
			_db.Courses.Add(course);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		return View(course);
	}

	public IActionResult Edit (int? id)
	{
		if (id == null || id == 0)
		{
			return NotFound();
		}
		var courseFromDb = _db.Courses.FirstOrDefault(u => u.Id == id);

		if (courseFromDb == null)
		{
			return NotFound();
		}
		return View(courseFromDb);
	}

	[HttpPost]
	public IActionResult Edit(Course obj)
	{

		if (ModelState.IsValid)
		{
			_db.Courses.Update(obj);
			_db.SaveChanges();
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
		var courseFromDb = _db.Courses.FirstOrDefault(u => u.Id == id);

		if (courseFromDb == null)
		{
			return NotFound();
		}
		return View(courseFromDb);
	}

	[HttpPost]
	public IActionResult Delete(Course obj)
	{

			_db.Courses.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
	}

}
