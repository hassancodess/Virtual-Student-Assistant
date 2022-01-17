using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Virtual_Student_Assistant.Models;
using System.IO;

namespace Virtual_Student_Assistant.Controllers
{
    public class ActivityController : Controller
    {
        static string constr = @"Data Source=HASSAN\SQLEXPRESS;Initial Catalog=VirtualStudentAssistant;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        // GET: Activity
        public ActionResult ActivityEntry()
        {
            if (Session["ID"] != null && Session["Name"] != null && Session["Email"] != null)
            {
                TempData["ID"] = int.Parse(Session["ID"].ToString());
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]

        public ActionResult ActivityEntry(Activity a, string starttime, string endtime)
        {
            a.T_ID = (int)TempData["ID"];

            var aext = new[] { ".pdf", ".docx" };
            var fext = Path.GetExtension(a.File.FileName); //s.image.FileName => 123.jpg      // .jpg
            if (aext.Contains(fext))
            {
                var folderpath = Path.Combine(Server.MapPath("~/images"), (TempData["ID"]  + a.File.FileName + fext));
                a.File.SaveAs(folderpath);
                string DBpath = "/images/" + TempData["ID"] + a.File.FileName + fext; // ~/images/123.jpg
                con.Open();
                string query = "insert into Activity(t_id,name,description,semester,filepath,starttime,endtime) values ('" + a.T_ID + "','" + a.Name + "','" + a.Description + "','" + a.Semester + "', '" + DBpath + "', '"+starttime+"', '"+endtime+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return View();
        }

        public ActionResult ActivityData()
        {
            if (Session["ID"] != null && Session["Name"] != null && Session["Email"] != null)
            {
                TempData["ID"] = int.Parse(Session["ID"].ToString());
                List<Activity> aList = new List<Activity>();
                con.Open();
                string query = "select * from Activity where t_id='" + TempData["ID"] + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Activity a = new Activity();
                    a.A_ID = int.Parse(sdr["a_id"].ToString());
                    a.T_ID = int.Parse(sdr["t_id"].ToString());
                    a.Name = sdr["name"].ToString();
                    a.Description = sdr["description"].ToString();
                    a.Semester = int.Parse(sdr["semester"].ToString());
                    a.filePath = sdr["filepath"].ToString();
                    a.StartTime = sdr["starttime"].ToString();
                    a.EndTime = sdr["endtime"].ToString();
                    aList.Add(a);
                }
                sdr.Close();
                con.Close();

                return View(aList);
            }
            return RedirectToAction("Login", "Home");
        }
    }
}