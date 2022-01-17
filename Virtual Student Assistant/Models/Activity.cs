using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Virtual_Student_Assistant.Models
{
    public class Activity
    {
        public int A_ID{ get; set; }
        public int T_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Course{ get; set; }
        public int Semester { get; set; }
        public string filePath { get; set; }
        public string StartTime { get; set; }
        public string  EndTime { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}