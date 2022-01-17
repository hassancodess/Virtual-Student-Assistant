using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Virtual_Student_Assistant.Models
{
    public class Course
    {
        public int C_ID { get; set; }
        public int T_ID { get; set; }
        public string Name{ get; set; }
        public int Semester { get; set; }
    }
}