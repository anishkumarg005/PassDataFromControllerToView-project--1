using PassDataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassDataFromControllerToView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.FirstName = "Anish";
            ViewBag.LastName = "Kumar";
            ViewBag.Address = "Coimbatore";

            TempData["Employee"] = "raj";
            return View();
        }
        public ActionResult GetEmployee()

        {
            List<Employee> employees = new List<Employee>()
            {


                new Employee()
                {
                    EmployeeID = 1,
                    EmployeeName = "arun",
                    Address = "chennai",
                    DateOfJoining = System.DateTime.Now,
                    MaterialStatus = 1,
                    IsEligibleForLoan = true,
                    salary = 15000.00m,
                    CreatedBy = "admin",
                    CreatedDate = System.DateTime.Now
                },

                new Employee()
                {
                    EmployeeID = 2,
                    EmployeeName = "abishek",
                    Address = "erode",
                    DateOfJoining = System.DateTime.Now,
                    MaterialStatus = 1,
                    IsEligibleForLoan = true,
                    salary = 20000.00m,
                    CreatedBy = "admin",
                    CreatedDate = System.DateTime.Now
                },


                new Employee()
                {
                    EmployeeID = 3,
                    EmployeeName = "karthick",
                    Address = "ooty",
                    DateOfJoining = System.DateTime.Now,
                    MaterialStatus = 1,
                    IsEligibleForLoan = true,
                    salary = 22000.00m,
                    CreatedBy = "admin",
                    CreatedDate = System.DateTime.Now
                },

                new Employee()
            {
                EmployeeID = 4,
                EmployeeName = "kumar",
                Address = "salem",
                DateOfJoining = System.DateTime.Now,
                MaterialStatus = 1,
                IsEligibleForLoan = false,
                salary = 18000.00m,
                CreatedBy = "admin",
                CreatedDate = System.DateTime.Now
            }
        };
           
            ViewBag.Employees = employees;
            return View();
        }
    }
}