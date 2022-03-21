using PassDataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassDataFromControllerToView.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName{ get; set; }
        public string Address { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int MaterialStatus { get; set; } 
        public bool IsEligibleForLoan { get; set; } 
        public decimal salary { get; set; } 
        public string CreatedBy { get; set; }   
        public DateTime CreatedDate { get; set; }   

    }
    }
