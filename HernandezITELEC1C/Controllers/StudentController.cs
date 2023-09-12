using Microsoft.AspNetCore.Mvc;
using HernandezITELEC1C.Models;

namespace HernandezITELEC1C.Controllers
{
    public class StudentController : Controller
    {


        public IActionResult Index()
        {
            Student st = new Student();
            st.StudentId = 1;
            st.StudentName = "Robrigoz";
            st.DateEnrolled = DateTime.Parse("30/04/2002");
            st.StudentCourse = Course.BSIT;
            st.Email = "kenshin@gmail.com";
            ViewBag.student = st;

            return View();
        }
    }
}
