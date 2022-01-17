using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virtual_Student_Assistant.Models;
using System.Data.SqlClient;

namespace Virtual_Student_Assistant.Controllers
{
    public class CourseController : Controller
    {
        static string constr = @"Data Source=HASSAN\SQLEXPRESS;Initial Catalog=VirtualStudentAssistant;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);

        [HttpGet]
        public ActionResult CourseEntry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourseEntry(Course c)
        {
            con.Open();
            string query = "insert into Courses values('" +Session["ID"] + "','" + c.Name + "','" + c.Semester+ "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }
        [HttpGet]
        public ActionResult ViewCourses()
        {
            var cList = new List<Course>();
            con.Open();
            String query = "Select C_ID, Name, Semester from Courses";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var c = new Course();
                c.C_ID = int.Parse(sdr[0].ToString());
                c.Name= sdr[1].ToString();
                c.Semester= int.Parse(sdr[2].ToString());
                cList.Add(c);
            }
            con.Close();
            return View(cList);
        }
    }
}