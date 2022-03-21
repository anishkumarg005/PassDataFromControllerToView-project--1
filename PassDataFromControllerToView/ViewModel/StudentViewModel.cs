using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassDataFromControllerToView.Models;

namespace PassDataFromControllerToView.ViewModel
{
    public class StudentViewModel
    {
        public Student Student { get; set; }    
        public IEnumerable<Subject> subject { get; set; }
        
    }
}