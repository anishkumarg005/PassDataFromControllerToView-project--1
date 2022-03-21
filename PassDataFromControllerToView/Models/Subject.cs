using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassDataFromControllerToView.Models;

namespace PassDataFromControllerToView.Models
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
    }
    public class Subject
    {
        public int Id { get; set; } 
        public string Name { get; set; }  
        

    }
}