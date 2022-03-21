using PassDataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PassDataFromControllerToView.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult GetStudents()
        {
            var student = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="Vinil",
                    Address="chennai"
                },
               new Student()
        {
                    Id=2,
                    Name="Deepak",
                    Address="andipati"
                },
                new Student()
                {
                    Id=2,
                    Name="tony",
                    Address="Madurai"
                }
             };

            return View(student);
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

        //routes.MapRoute(
                //"StudentByPassingYear",
               // "student/bypassingyear/{month}/{Year}",
                // new { controller = "Student", action = "ByPassingYear" }
               // );


        //Range,Min,Max and Regex for regular expressions
        //datatype

        [Route("student/passingyear/{month:int:range(1,12)}/{year:min(1990)}")]
        public ActionResult ByPassingYear(int month,int year)
        {
            return Content("Month:" + month + "Year:" + year);
        }
    }
}