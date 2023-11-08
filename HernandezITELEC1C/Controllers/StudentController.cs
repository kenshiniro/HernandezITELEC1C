using Microsoft.AspNetCore.Mvc;
using HernandezITELEC1C.Models;
using HernandezITELEC1C.Data;

namespace HernandezITELEC1C.Controllers
{
    public class StudentController : Controller
    {

        private readonly AppDbContext _dbData;
     
        public StudentController(AppDbContext dbData)
        {
            _dbData = dbData;

        }





        /*public IActionResult Index()
        {
            Student st = new Student();
            st.StudentId = 1;
            st.StudentName = "Robrigoz";
            st.DateEnrolled = DateTime.Parse("30/04/2002");
            st.StudentCourse = Course.BSIT;
            st.Email = "kenshin@gmail.com";
            ViewBag.student = st;

            return View();
        }*/

        public IActionResult Index()
        {

            return View(_dbData.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();
        }
       [HttpGet]
        public IActionResult AddStudent()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {

            if (!ModelState.IsValid)
                return View();

            _dbData.Students.Add(newStudent);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an student found?
                return View(student);

            return NotFound();

            
        }
       
        [HttpPost]


        public IActionResult UpdateStudent(Student studentChanges)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == studentChanges.Id);
            if (student != null)
            {
                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Email = studentChanges.Email;   
                student.Course = studentChanges.Course;
                student.GPA = studentChanges.GPA;
                student.AdmissionDate = studentChanges.AdmissionDate;
                _dbData.SaveChanges();

            }
            return RedirectToAction("Index");
        }

         [HttpGet]
        public IActionResult DeleteStudent(int id)
        {

            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was a student found?
                return View(student);

            return NotFound();


        }
        [HttpPost]
        public IActionResult DeleteStudent(Student newStudent)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == newStudent.Id);
            if (student != null)
            {
                _dbData.Students.Remove(student);
                _dbData.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
