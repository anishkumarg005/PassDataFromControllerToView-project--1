using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassDataFromControllerToView.Models;
using PassDataFromControllerToView.ViewModel;

namespace PassDataFromControllerToView.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult GetStudents( )
        {
            var student = new Student() { Id = 1, Name = "anish", Address = "Coimbatore" };
            var subject = new List<Subject>()
            {
                new Subject() {Id=1,Name="Computer Programming"},
                new Subject() {Id=2,Name="DataBase Analysis"},
                new Subject() {Id=3,Name="Fundamental of Algorthim"},
            };
            var ViewModel= new StudentViewModel()
            {
                Student = student,
                subject=subject
            };
            return View(ViewModel);
        }

        public ActionResult CreateStudent()
        {
            var student = new Student() { Id = 1, Name = "raj", Address = "chennai" };
            return View(student);
        }
        public ActionResult SingleStudent()
        {
            return View();
        }
        public ActionResult EditStudent(int id)
        {
            return Content("Student Id" + id);
        }
    }
}
