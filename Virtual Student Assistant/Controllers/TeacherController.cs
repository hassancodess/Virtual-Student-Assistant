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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
    }
}