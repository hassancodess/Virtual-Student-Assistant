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
        public ActionResult Signup()
        {
            return View();
        }

    }
}