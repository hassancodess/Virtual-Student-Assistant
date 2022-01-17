using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virtual_Student_Assistant.Models;
using Virtual_Student_Assistant.Controllers;
using System.Data.SqlClient;
//using System.Web.Routing;

namespace Virtual_Student_Assistant.Controllers
{
    public class HomeController : Controller
    {
        static string constr = @"Data Source=HASSAN\SQLEXPRESS;Initial Catalog=VirtualStudentAssistant;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult TeacherSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeacherSignup(Teacher t)
        {
            con.Open();
            string query = "Insert into Teacher Values('" + t.Name + "','" + t.Email + "','" + t.Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }

        [HttpGet]
        public ActionResult StudentSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentSignup(Student s)
        {
            con.Open();
            string query = "Insert into Student Values('" + s.Name + "','" + s.Email + "','" + s.Password + "','" + s.Semester + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }




        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Teacher t)
        {
            try
            {
                HttpCookie c;
                con.Open();
                string query = "Select * from Teacher where Email='" + t.Email + "'and Password='" + t.Password + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    Session["ID"] = sdr[0].ToString();
                    Session["Name"] = sdr[1].ToString();
                    Session["Email"] = sdr[2].ToString();

                    // Cookie START
                    c = new HttpCookie("Login");
                    c["idpass"] = sdr[1].ToString() + "," + t.Email;
                    Response.Cookies.Add(c);
                    c.Expires = DateTime.Now.AddDays(10);
                    // Cookie END

                    sdr.Close();
                    con.Close();
                    //return RedirectToAction("TeacherHome", "Teacher", new RouteValueDictionary(t));
                    return RedirectToAction("TeacherHome", "Teacher");
                }
                sdr.Close();
                query = "Select * from Student where Email='" + t.Email + "'and Password='" + t.Password + "' ";
                cmd = new SqlCommand(query, con);
                sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    Session["ID"] = sdr[0].ToString();
                    Session["Name"] = sdr[1].ToString();
                    Session["Email"] = sdr[2].ToString();
                    Session["Semester"] = sdr[4].ToString();
                    // Cookie START
                    c = new HttpCookie("Login");
                    c["idpass"] = sdr[1].ToString() + "," + t.Email + "," + sdr[4].ToString();
                    Response.Cookies.Add(c);
                    c.Expires = DateTime.Now.AddDays(10);
                    // Cookie END
                    sdr.Close();
                    con.Close();
                    //return RedirectToAction("StudentHome", "Student", new RouteValueDictionary(t));
                    return RedirectToAction("StudentHome", "Student");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return RedirectToAction("");
        }
    }
}