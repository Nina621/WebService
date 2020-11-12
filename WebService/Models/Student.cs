using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int StudentJMBAG { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

        public string StudentGender { get; set; }

        public string StudentCity { get; set; }
        public string StudentDirection { get; set; }

        public int YearOfCollage { get; set; }
    }
}