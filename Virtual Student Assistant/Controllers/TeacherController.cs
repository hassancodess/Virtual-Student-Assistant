using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virtual_Student_Assistant.Models;

namespace Virtual_Student_Assistant.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult TeacherHome()
        {
            if (Session["ID"] != null && Session["Name"] != null && Session["Email"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult AddActivity()
        {
            TempData["T_ID"] = int.Parse(Session["ID"].ToString());
            return View();
        }        
        [HttpPost]
        public ActionResult AddActivity(Activity a)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewActivity()
        {
            return View();
        }
    }
}