using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        public string ProfessorName { get; set; }
        public string ProfessorSurname { get; set; }
        public string ProfessorSubject { get; set; }
        public DateTime Date_Time { get; set; }
    }
}