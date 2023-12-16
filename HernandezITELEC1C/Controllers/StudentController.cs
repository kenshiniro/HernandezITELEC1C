using Microsoft.AspNetCore.Mvc;
using HernandezITELEC1C.Models;
using HernandezITELEC1C.Data;

namespace HernandezITELEC1C.Controllers
{
    public class StudentController : Controller
    {

        private readonly AppDbContext _dbData;
        private readonly IWebHostEnvironment _environment;
     
        public StudentController(AppDbContext dbData, IWebHostEnvironment environment)
        {
            _dbData = dbData;
            _environment = environment;
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
           /* if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                newStudent.StudentProfilePhoto = ms.ToArray();
                ms.Close();
                ms.Dispose();

            } */
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            

            /* if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                newStudent.StudentProfilePhoto = ms.ToArray();
                ms.Close();
                ms.Dispose();

            } */

            if (!ModelState.IsValid)
                return View();


            string folder = "students/images/";
            string servFolder = Path.Combine(_environment.WebRootPath, folder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + newStudent.UploadedPhoto.FileName;
            string filePath = Path.Combine(servFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                newStudent.UploadedPhoto.CopyTo(fileStream);
            }
            newStudent.ImagePath = folder + uniqueFileName;



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
