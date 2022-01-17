using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Virtual_Student_Assistant.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentHome()
        {
            if (Session["ID"] != null && Session["Name"] != null && Session["Email"] != null && Session["Semester"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
        
        public ActionResult ViewActivity()
        {
            return View();
        }
        public ActionResult SearchActivity()
        {
            return View();
        }

    }
}